using CroudiaSharp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CroudiaSharp.Extensions;

namespace CroudiaSharp.Http {
    internal class HttpHelper {
        internal enum HttpType {
            GET,
            POST
        }

        internal HttpHelper() {
        }

        private String ObjectToString(object obj) {
            if(obj is IEnumerable<string>){
                return (obj as IEnumerable<string>).JoinString(",");
            }else if(obj is IEnumerable<int>){
                return (obj as IEnumerable<int>).JoinString(",");
            } else if(obj is IEnumerable<long>) {
                return (obj as IEnumerable<long>).JoinString(",");
            } else {
                return obj.ToString();
            }
        }

        public HttpResponseMessage Send(HttpData data,HttpType type,Token token,bool isHeader=true) {
            using(HttpClient client = new HttpClient()) {
                client.Timeout = TimeSpan.FromSeconds(token.Config.TimeOut);
                if(isHeader==true) {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType,token.AccessToken);
                }
                switch(type) {
                    case HttpType.GET:
                        StringBuilder request = new StringBuilder();
                        foreach(KeyValuePair<string,object> v in data.Param) {
                            if(request.Length > 0) {
                                request.Append('&');
                            }
                            request.Append(v.Key);
                            request.Append('=');
                            request.Append(Uri.EscapeDataString(ObjectToString(v.Value)));
                        }
                        return client.GetAsync(data.Url + "?" + request.ToString()).Result;
                    case HttpType.POST:
                        HttpContent content = null;
                        if(data.FileParam.Count == 0) {
                            content = new FormUrlEncodedContent(data.Param.Select(x => new KeyValuePair<string,string>(x.Key,ObjectToString(x.Value))));
                        } else {
                            MultipartFormDataContent con = new MultipartFormDataContent();
                            if(data.Param.Count > 0) {
                                foreach(KeyValuePair<string,object> v in data.Param) {
                                    StringContent c = new StringContent(ObjectToString(v.Value));
                                    con.Add(c,v.Key);
                                }
                            }
                            foreach(KeyValuePair<string,object> v in data.FileParam) {
                                try {
                                    FileStream stream = File.Open(v.Value.ToString(),FileMode.Open);
                                    StreamContent sc = new StreamContent(stream);
                                    if(v.Key.EndsWith("png") == true) {
                                        sc.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                                    } else if(v.Key.EndsWith("gif") == true) {
                                        sc.Headers.ContentType = MediaTypeHeaderValue.Parse("image/gif");
                                    } else {
                                        sc.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                                    }
                                    con.Add(sc,"image",v.Key);
                                } catch(Exception) { }
                            }
                            content = con;
                        }
                        return client.PostAsync(data.Url,content).Result;
                    default:
                        return null;
                }
            }
        }

        internal HttpResponseMessage SendAndCheck(HttpData data,HttpHelper.HttpType type,Token token) {
            if(token.ExpiresIn > DateTime.Now) {
                token.Oauth.Token();
            }
            int roop = 1;
            for(int i = 0;i < roop;i++) {
                try {
                    HttpResponseMessage res = Send(data,type,token);
                    CheckError(res);
                    if(token.Config.IsLog) {
                        Console.Out.WriteLine(res.Content.ReadAsStringAsync().Result);
                    }
                    return res;
                } catch(CroudiaSharpException e) {
                    if(e.IsInvalidGrant == true) {
                        roop++;
                        token.Oauth.Token();
                    } else {
                        throw;
                    }
                }
            }
            return null;
        }

        internal void CheckError(HttpResponseMessage res) {
            if(res.IsSuccessStatusCode == false) {
                var errorSerializer = new DataContractJsonSerializer(typeof(Error));
                using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                    var e = errorSerializer.ReadObject(stream) as Error;
                    var ex = e != null ? new CroudiaSharpException(e) : null;
                    ex = ex ?? new CroudiaSharpException("cannot find exception");
                    ex.Code = (int)res.StatusCode;
                    throw ex;
                }
            }           
        }

    }
}
