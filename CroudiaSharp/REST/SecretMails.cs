using CroudiaSharp.Data;
using CroudiaSharp.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.REST {
    public class SecretMails : DataConvert {
        private Token token;
        internal SecretMails(Token token)
            : base() {
            this.token = token;
        }

        public List<SecretMail> Get(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.SecretMailsGet);
            data.Param = param;
            return ToSecretMailList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<SecretMail> Get(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.SecretMailsGet);
            data.Param = MakeParam(param);
            return ToSecretMailList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<SecretMail> Sent(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.SecretMailsSent);
            data.Param = param;
            return ToSecretMailList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public List<SecretMail> Sent(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.SecretMailsSent);
            data.Param = MakeParam(param);
            return ToSecretMailList(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public SecretMail New(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.SecretMailsNew);
            data.Param = param;
            return ToSecretMail(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public SecretMail New(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.SecretMailsNew);
            data.Param = MakeParam(param);
            return ToSecretMail(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        //できない気がする
        public SecretMail NewWithMedia(IDictionary<string,object> param) {
            HttpData data = new HttpData(APIConstant.SecretMailsNewWithMedia);
            data.Param = MakeParam(param);
            data.FileParam = MakeFileParam(param);
            return ToSecretMail(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        //できない気がする
        public SecretMail NewWithMedia(params Expression<Func<string,object>>[] param) {
            HttpData data = new HttpData(APIConstant.SecretMailsNewWithMedia);
            data.Param = MakeParam(param);
            data.FileParam = MakeFileParam(param);
            return ToSecretMail(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public SecretMail Destroy(long id) {
            HttpData data = new HttpData(APIConstant.SecretMailsDestroy+id+".json");
            return ToSecretMail(token.Http.SendAndCheck(data,HttpHelper.HttpType.POST,token));
        }

        public SecretMail Show(long id) {
            HttpData data = new HttpData(APIConstant.SecretMailsShow + id + ".json");
            return ToSecretMail(token.Http.SendAndCheck(data,HttpHelper.HttpType.GET,token));
        }

        public Image GetSecretPhoto(long id) {
            HttpData data = new HttpData(APIConstant.SecretMailsGetSecretPhoto + id);
            HttpResponseMessage res  = token.Http.Send(data,HttpHelper.HttpType.GET,token);
            token.Http.CheckError(res);
            return Image.FromStream(res.Content.ReadAsStreamAsync().Result);
        }

    }
}
