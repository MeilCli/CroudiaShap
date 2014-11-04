using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CroudiaSharp.Data;

namespace CroudiaSharp {

    public class CroudiaSharpException : Exception {

        public CroudiaSharpException() : base() { }

        public CroudiaSharpException(Error e)
            : base() {
            this.Error = e.ErrorMessage;
        }

        public CroudiaSharpException(string error)
            : base(error) {
            this.Error = error;
        }

        private string _error;
        public string Error {
            private set {
                this._error = value;
                init(value);
            }
            get {
                return _error;
            }
        }

        public string ErrorDetail { private set; get; }
        public bool IsInvalidGrant { private set; get; }

        private void init(string error) {
            switch(error) {
                //https://developer.croudia.com/docs/oauth
                case "invalid_request":
                    this.ErrorDetail = "リクエストに必要なパラメーターがない場合、もしくは不正な場合";
                    break;
                case "unauthorized_client":
                    this.ErrorDetail = "クライアントがリクエストの際に指定したresponse_typeが許可されていない場合";
                    break;
                case "access_denied":
                    this.ErrorDetail = "エンドユーザーまたは認可サーバーがリクエストを拒否した場合";
                    break;
                case "unsupported_response_type":
                    this.ErrorDetail = "認可サーバーがリクエストの際に指定したresponse_typeによる認可コード取得をサポートしていない場合";
                    break;
                case "invalid_scope":
                    this.ErrorDetail = "リクエストスコープが不正, 未知, もしくはその他の不当な形式である場合 ";
                    break;
                case "server_error":
                    this.ErrorDetail = "認可サーバーに何らかのエラーが発生した場合";
                    break;
                case "invalid_client":
                    this.ErrorDetail = "クライアント識別IDもしくはクライアントシークレットが正しくなく認証できない場合";
                    break;
                case "invalid_grant":
                    this.ErrorDetail = "リクエストに含まれていた認可コード（またはリフレッシュトークン）が期限切れ等、正しくない場合";
                    this.IsInvalidGrant = true;
                    break;
                case "unsupported_grant_type":
                    this.ErrorDetail = "grant_typeにauthorization_codeやrefresh_token以外が指定されていた場合";
                    break;
                default:
                    this.ErrorDetail = string.Empty;
                    break;
            }
        }

        private int _code = -1;
        public int Code {
            internal set {
                _code = value;
                initMessage(value);
            }
            get {
                return _code;
            }
        }

        public string ErrorMessage { private set; get; }

        private void initMessage(int code) {
            switch(code) {
                //https://developer.croudia.com/docs/206_response
                case 200:
                    this.ErrorMessage = "正常にAPI呼び出しが成功したことを示します。";
                    break;
                case 304:
                    this.ErrorMessage = "新しいデータがないことを示します。";
                    break;
                case 400:
                    this.ErrorMessage = "リクエストに不正がある場合やレートリミットに達している場合、OAuthのシグニチャに問題がある場合に返ります。エラーメッセージに詳しい原因が記されるので、内容を確認してからデバッグするか、ユーザーにメッセージを提示します。";
                    break;
                case 401:
                    this.ErrorMessage = "認証用の情報がない場合や誤っている場合に返ります。";
                    break;
                case 403:
                    this.ErrorMessage = "リクエストが拒否された場合に返ります。";
                    break;
                case 404:
                    this.ErrorMessage = "存在しないリソースへアクセスした場合に返ります。アクセス先のURLや指定したユーザーID、ステータスIDなどが存在するか確認してください。";
                    break;
                case 500:
                    this.ErrorMessage = "サーバ側で問題が発生した場合に返ります。";
                    break;
                case 502:
                    this.ErrorMessage = "Croudiaに障害が発生しているか、サービスのアップグレード中です。";
                    break;
                case 503:
                    this.ErrorMessage = "Croudiaが過負荷になった場合に返ります。";
                    break;
                default:
                    this.ErrorMessage = string.Empty;
                    break;
            }
        }

        public override string ToString() {
            return "Error : " + Error + " ErrorDetail : " + ErrorDetail + (Code > 0 ? " Code : " + Code + " ErrorMessage : " + ErrorMessage : "");
        }

    }
}
