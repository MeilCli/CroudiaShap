using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CroudiaSharp.Data {
    [DataContract]
    public class Entity {

        internal Entity() { }

        [DataMember(Name = "media")]
        public MediaEntity Media { internal set; get; }

    }

    [DataContract]
    public class MediaEntity {

        internal MediaEntity() { }

        private string _mediaUrl;
        [DataMember(Name = "media_url_https")]
        public string MediaUrl {
            internal set {
                _mediaUrl = value;
                try {
                    Id = long.Parse(value.Substring(value.LastIndexOf('/') + 1));
                } catch { }
            }
            get {
                return _mediaUrl;
            }
        }

        public long Id { internal set; get; }

        [DataMember(Name = "type")]
        public string Type { internal set; get; }

    }
}
