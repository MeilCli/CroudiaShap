using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.Data {
    [DataContract]
    public class Status {
        internal Status() { }

        private string _createdAt;
        private DateTime _createdAtTime;
        [DataMember(Name = "created_at")]
        private string _CreatedAtTime {
            set {
                _createdAtTime = DateTime.ParseExact(value,"ddd, dd MMM yyyy HH:mm:ss zzzz",DateTimeFormatInfo.InvariantInfo,DateTimeStyles.None);
                _createdAt = value;
            }
            get {
                return _createdAt;
            }

        }
        public DateTime CreatedAt {
            internal set {
                _createdAt = value.ToString("ddd, dd MMM yyyy HH:mm:ss zzzz",DateTimeFormatInfo.InvariantInfo);
                _createdAtTime = value;
            }
            get {
                return _createdAtTime;
            }
        }

        [DataMember(Name = "favorited")]
        public bool IsFavorited { internal set; get; }
        [DataMember(Name = "favorited_count")]
        public int FavoritedCount { internal set; get; }
        [DataMember(Name = "id")]
        public long Id { internal set; get; }
        [DataMember(Name = "in_reply_to_screen_name")]
        public string InReplyToScreenName { internal set; get; }

        private long? _inReplyToStatusId;
        [DataMember(Name = "in_reply_to_status_id")]
        private long? _InReplyToStatusId {
            set {
                _inReplyToStatusId = value;
                InReplyToStatusId = value ?? -1;
            }
            get {
                return _inReplyToStatusId;
            }
        }
        public long InReplyToStatusId { internal set; get; }

        private long? _inReplyToUserId;
        [DataMember(Name = "in_reply_to_user_id")]
        private long? _InReplyToUserId {
            set {
                _inReplyToUserId = value;
                InReplyToUserId = value ?? -1;
            }
            get {
                return _inReplyToUserId;
            }
        }
        public long InReplyToUserId { internal set; get; }

        [DataMember(Name = "spread_count")]
        public int SpreadCount { internal set; get; }
        [DataMember(Name = "spread")]
        public bool IsSpread { internal set; get; }
        [DataMember(Name = "spread_status")]
        public Status SpreadStatus { internal set; get; }
        [DataMember(Name = "reply_status")]
        public Status ReplyStatus { internal set; get; }
        [DataMember(Name = "source")]
        public Source Source { internal set; get; }
        [DataMember(Name = "text")]
        public string Text { internal set; get; }
        [DataMember(Name = "user")]
        public User User { internal set; get; }
        [DataMember(Name = "entities")]
        public Entity Entities { internal set; get; }

    }

    [DataContract]
    public class Source {
        internal Source() { }

        [DataMember(Name = "name")]
        public string Name { internal set; get; }
        [DataMember(Name = "url")]
        public string Url { internal set; get; }

    }
}
