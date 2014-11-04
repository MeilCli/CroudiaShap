using CroudiaSharp.Data;
using CroudiaSharp.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.REST {
    public class Account : DataConvert {
        private Token token;

        internal Account(Token token)
            : base() {
            this.token = token;
        }

        public User VerifyCredentials() {
            HttpData data = new HttpData(APIConstant.AccountVerifyCredentials);
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public User UpdateProfileImage(string filePath) {
            HttpData data = new HttpData(APIConstant.AccountUpdateProfileImage);
            data.FileParam = new Dictionary<string,object>() { { "image",filePath } };
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public User UpdateCoverImage(string filePath) {
            HttpData data = new HttpData(APIConstant.AccountUpdateCoverImage);
            data.FileParam = new Dictionary<string,object>() { { "image",filePath } };
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public User UpdateProfile(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.AccountUpdateProfile);
            data.Param = param;
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public User UpdateProfile(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.AccountUpdateProfile);
            data.Param = MakeParam(param);
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }
        
    }
}
