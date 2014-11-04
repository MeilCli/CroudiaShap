using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.Data {
    [DataContract]
    public class SecretMail {

        internal SecretMail() { }

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

        [DataMember(Name = "id")]
        public long Id { internal set; get; }
        [DataMember(Name = "recipient")]
        public User RecipientUser { internal set; get; }
        [DataMember(Name = "recipient_id")]
        public long RecipientId { internal set; get; }
        [DataMember(Name = "recipient_screen_name")]
        public string RecipientScreenName { internal set; get; }
        [DataMember(Name = "sender")]
        public User SenderUser { internal set; get; }
        [DataMember(Name = "sender_id")]
        public long SenderId { internal set; get; }
        [DataMember(Name = "sender_screen_name")]
        public string SenderScreenName { internal set; get; }
        [DataMember(Name = "text")]
        public string Text { internal set; get; }
        [DataMember(Name = "entities")]
        public Entity Entities { internal set; get; }

    }
}
