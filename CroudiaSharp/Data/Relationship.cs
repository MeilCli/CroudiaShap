using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.Data {
    [DataContract]
    public class Friendship {
        internal Friendship() { }

        [DataMember(Name = "relationship")]
        public Relationship Relationship { internal set; get; }

    }

    [DataContract]
    public class Relationship {
        internal Relationship() { }

        [DataMember(Name = "source")]
        public RelationshipSource Source { internal set; get; }
        [DataMember(Name = "target")]
        public RelationshipTarget Target { internal set; get; }

    }

    [DataContract]
    public class RelationshipSource {
        internal RelationshipSource() { }

        private bool? _isBlocking;
        [DataMember(Name = "blocking")]
        private bool? _IsBlocking {
            set {
                _isBlocking = value;
                IsBlocking = _isBlocking ?? false;
            }
            get {
                return _isBlocking;
            }
        }
        public bool IsBlocking { internal set; get; }

        private bool? _isMuting;
        [DataMember(Name = "muting")]
        private bool? _IsMuting {
            set {
                _isMuting = value;
                IsMuting = _isMuting ?? false;
            }
            get {
                return _isMuting;
            }
        }
        public bool IsMuting { internal set; get; }

        [DataMember(Name = "followed_by")]
        public bool IsFollowedBy { internal set; get; }
        [DataMember(Name = "following")]
        public bool IsFollowing { internal set; get; }
        [DataMember(Name = "id")]
        public long Id { internal set; get; }
        [DataMember(Name = "screen_name")]
        public string ScreenName { internal set; get; }

    }

    [DataContract]
    public class RelationshipTarget {
        internal RelationshipTarget() { }

        [DataMember(Name = "followed_by")]
        public bool IsFollowedBy { internal set; get; }
        [DataMember(Name = "following")]
        public bool IsFollowing { internal set; get; }
        [DataMember(Name = "id")]
        public long Id { internal set; get; }
        [DataMember(Name = "screen_name")]
        public string ScreenName { internal set; get; }

    }
}
