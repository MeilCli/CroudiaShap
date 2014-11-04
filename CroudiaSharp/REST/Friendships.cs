using CroudiaSharp.Data;
using CroudiaSharp.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.REST {
    public class Friendships :DataConvert{
        private Token token;

        internal Friendships(Token token) {
            this.token = token;
        }

        public User Create(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.FriendshipsCreate);
            data.Param = param;
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public User Create(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.FriendshipsCreate);
            data.Param = MakeParam(param);
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public User Destroy(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.FriendshipsDestroy);
            data.Param = param;
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public User Destroy(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.FriendshipsDestroy);
            data.Param = MakeParam(param);
            return ToUser(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Friendship Show(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.FriendshipsShow);
            data.Param = param;
            return ToFriendship(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public Friendship Show(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.FriendshipsShow);
            data.Param = MakeParam(param);
            return ToFriendship(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

    }
}
