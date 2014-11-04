using CroudiaSharp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp {
    public class DataConvert {
        internal DataConvert() { }

        internal Dictionary<string,object> MakeParam(IDictionary<string,object> param) {
            return param.Where(x => x.Key != "media").ToDictionary(x => x.Key,x => x.Value);
        }

        internal Dictionary<string,object> MakeFileParam(IDictionary<string,object> param) {
            return param.Where(x => x.Key == "media").ToDictionary(x => x.Key,x => x.Value);
        }

        internal Dictionary<string,object> MakeParam(params Expression<Func<string,object>>[] param) {
            return param.Where(x => x.Parameters[0].Name != "media").Select(
                x => new KeyValuePair<string,object>(x.Parameters[0].Name.ToString(),x.Compile()(""))
                ).ToDictionary(x => x.Key,x => x.Value);
        }

        internal Dictionary<string,object> MakeFileParam(params Expression<Func<string,object>>[] param) {
            return param.Where(x => x.Parameters[0].Name == "media").Select(
                x => new KeyValuePair<string,object>(x.Parameters[0].Name.ToString(),x.Compile()(""))
                ).ToDictionary(x => x.Key,x => x.Value);
        }

        internal Token ToToken(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(Token));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as Token;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot Token cast");
                }
                return v;
            }
        }

        internal List<User> ToUserList(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(List<User>));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as List<User>;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot List<User> cast");
                }
                return v;
            }
        }

        internal User ToUser(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(User));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as User;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot User cast");
                }
                return v;
            }
        }

        internal List<Status> ToStatusList(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(List<Status>));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as List<Status>;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot List<Status> cast");
                }
                return v;
            }
        }

        internal Status ToStatus(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(Status));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as Status;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot Status cast");
                }
                return v;
            }
        }

        internal List<SecretMail> ToSecretMailList(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(List<SecretMail>));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as List<SecretMail>;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot List<SecretMail> cast");
                }
                return v;
            }
        }

        internal SecretMail ToSecretMail(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(SecretMail));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as SecretMail;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot SecretMail cast");
                }
                return v;
            }
        }

        internal Friendship ToFriendship(HttpResponseMessage res) {
            var serializer = new DataContractJsonSerializer(typeof(Friendship));
            using(var stream = new MemoryStream(res.Content.ReadAsByteArrayAsync().Result)) {
                var v = serializer.ReadObject(stream) as Friendship;
                if(v == null) {
                    throw new CroudiaSharpException("cannnot Friendship cast");
                }
                return v;
            }
        }

    }
}
