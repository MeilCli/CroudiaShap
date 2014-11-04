using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.Http {
    internal class HttpData {

        internal HttpData(string url) {
            this.Url = url;
        }

        public string Url { set; get; }

        private IDictionary<string,object> _param;
        public IDictionary<string,object> Param {
            set {
                if(value != null) {
                    _param = value;
                }
            }
            get {
                if(_param != null) {
                    return _param;
                } else {
                    return new Dictionary<string,object>();
                }
            }
        }

        private IDictionary<string,object> _fparam;
        //key/filepass
        public IDictionary<string,object> FileParam {
            set {
                if(value != null) {
                    _fparam = value;
                }
            }
            get {
                if(_fparam != null) {
                    return _fparam;
                } else {
                    return new Dictionary<string,object>();
                }
            }
        }       
    }
}
