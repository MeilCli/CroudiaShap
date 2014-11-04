using CroudiaSharp.Data;
using CroudiaSharp.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.REST {
    public class Users : DataConvert {
        private Token token;

        internal Users(Token token)
            : base() {
            this.token = token;
        }

        public User Show(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.UsersShow);
            data.Param = param;
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public User Show(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.UsersShow);
            data.Param = MakeParam(param);
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<User> LookUp(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.UsersLookUp);
            data.Param = param;
            return ToUserList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<User> LookUp(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.UsersLookUp);
            data.Param = MakeParam(param);
            return ToUserList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<User> Search(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.UsersSearch);
            data.Param = param;
            return ToUserList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<User> Search(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.UsersSearch);
            data.Param = MakeParam(param);
            return ToUserList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }
    }
}
