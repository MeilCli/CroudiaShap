using CroudiaSharp.Data;
using CroudiaSharp.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.REST {
    public class Statuses : DataConvert {
        private Token token;

        internal Statuses(Token token)
            : base() {
            this.token = token;
        }

        public List<Status> PublicTimeLine(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesPublicTimeline);
            data.Param = param;
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<Status> PublicTimeLine(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesPublicTimeline);
            data.Param = MakeParam(param);
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<Status> HomeTimeLine(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesHomeTimeline);
            data.Param = param;
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<Status> HomeTimeLine(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesHomeTimeline);
            data.Param = MakeParam(param);
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<Status> UserTimeLine(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesUserTimeline);
            data.Param = param;
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<Status> UserTimeLine(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesUserTimeline);
            data.Param = MakeParam(param);
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<Status> Mentions(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesMentions);
            data.Param = param;
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<Status> Mentions(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesMentions);
            data.Param = MakeParam(param);
            return ToStatusList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public Status Update(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesUpdate);
            data.Param = param;
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Update(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesUpdate);
            data.Param = MakeParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        //なんかできない
        public Status UpdateWithMedia(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesUpdateWithMedia);
            data.Param = MakeParam(param);
            data.FileParam = MakeFileParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        //なんかできない
        public Status UpdateWithMedia(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesUpdateWithMedia);
            data.Param = MakeParam(param);
            data.FileParam = MakeFileParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Destroy(long id,IDictionary<string,object> param = null) {
            HttpData data = new HttpData(APIConstant.StatusesDestroy + id + ".json");
            data.Param = param;
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Destroy(long id,params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesDestroy + id + ".json");
            data.Param = MakeParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Show(long id,IDictionary<string,object> param = null) {
            HttpData data = new HttpData(APIConstant.StatusesDestroy + id + ".json");
            data.Param = param;
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Show(long id,params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesDestroy + id + ".json");
            data.Param = MakeParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Spread(long id,IDictionary<string,object> param = null) {
            HttpData data = new HttpData(APIConstant.StatusesSpread + id + ".json");
            data.Param = param;
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Spread(long id,params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesSpread + id + ".json");
            data.Param = MakeParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Share(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesShare);
            data.Param = param;
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public Status Share(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesShare);
            data.Param = MakeParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        //なんかできない気がする
        public Status ShareWithMedia(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.StatusesShareWithMedia);
            data.Param = MakeParam(param);
            data.FileParam = MakeFileParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        //なんかできない気がする
        public Status ShareWithMedia(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.StatusesShareWithMedia);
            data.Param = MakeParam(param);
            data.FileParam = MakeFileParam(param);
            return ToStatus(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

    }
}
