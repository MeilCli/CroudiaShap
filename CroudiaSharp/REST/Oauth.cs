using CroudiaSharp.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.REST {
    public class Oauth : DataConvert {
        private Token token;
        private string state;

        internal Oauth(Token token)
            : base() {
            this.token = token;
        }

        public string Authorize(string state = null) {
            this.state = state ?? DateTime.UtcNow.ToBinary().ToString();
            return APIConstant.OauthAuthorize + "?response_type=code&client_id=" + token.ConsumerKey + "&state=" + this.state;
        }

        public Token Token(string callback) {
            String text = callback.Substring(callback.LastIndexOf('?') + 1);
            String[] param = text.Split('&');
            String code = null;
            String state = null;
            String error = null;
            foreach(String p in param) {
                if(p == null || p.Length == 0) {
                    continue;
                }
                if(p.StartsWith("code")) {
                    code = p.Substring(p.IndexOf('=') + 1);
                } else if(p.StartsWith("state")) {
                    state = p.Substring(p.IndexOf('=') + 1);
                } else if(p.StartsWith("error")) {
                    error = p.Substring(p.IndexOf('=') + 1);
                }
            }
            if(error != null) {
                throw new CroudiaSharpException(error);
            } else if(this.state != state) {
                throw new CroudiaSharpException("not equal state");
            }
            HttpData data = new HttpData(APIConstant.OauthToken);
            data.Param = new Dictionary<string,object>() { { "grant_type","authorization_code" },{ "client_id",token.ConsumerKey },{ "client_secret",token.ConsumerSecret },{ "code",code } };
            HttpResponseMessage res = token.Http.Send(data,HttpHelper.HttpType.POST,token,false);
            token.Http.CheckError(res);
            Token tok = ToToken(res);
            token.AccessToken = tok.AccessToken;
            token.RefreshToken = tok.RefreshToken;
            token.TokenType = tok.TokenType;
            token.ExpiresIn = tok.ExpiresIn;
            return token;
        }

        public Token Token() {
            HttpData data = new HttpData(APIConstant.OauthToken);
            data.Param = new Dictionary<string,object>() { { "grant_type","refresh_token" },{ "client_id",token.ConsumerKey },{ "client_secret",token.ConsumerSecret },{ "refresh_token",token.RefreshToken } };
            HttpResponseMessage res = token.Http.Send(data,HttpHelper.HttpType.POST,token,false);
            token.Http.CheckError(res);
            Token tok = ToToken(res);
            token.AccessToken = tok.AccessToken;
            token.RefreshToken = tok.RefreshToken;
            token.TokenType = tok.TokenType;
            token.ExpiresIn = tok.ExpiresIn;
            return token;
        }

    }
}
