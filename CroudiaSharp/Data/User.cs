using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.Data {
    [DataContract]
    public class User {
        internal User() { }

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

        [DataMember(Name = "description")]
        public string Description { internal set; get; }
        [DataMember(Name = "favorites_count")]
        public int FavoritesCount { internal set; get; }

        private object _isFollowRequestSent;
        [DataMember(Name = "follow_request_sent")]
        private object _IsFollowRequestSent {
            set {
                _isFollowRequestSent = value;
                IsFollowRequestSent = value.ToString().Equals("true",StringComparison.OrdinalIgnoreCase);
            }
            get {
                return _isFollowRequestSent;
            }
        }
        public bool IsFollowRequestSent { internal set; get; }

        [DataMember(Name = "followers_count")]
        public int FollowersCount { internal set; get; }

        private object _isFollowing;
        [DataMember(Name = "following")]
        private object _IsFollowing {
            set {
                _isFollowing = value;
                IsFollowing = value.ToString().Equals("true",StringComparison.OrdinalIgnoreCase);
            }
            get {
                return _isFollowing;
            }
        }
        public bool IsFollowing { internal set; get; }
        
        [DataMember(Name = "friends_count")]
        public int FriendsCount { internal set; get; }
        [DataMember(Name = "id")]
        public long Id { internal set; get; }
        [DataMember(Name = "location")]
        public string Location { internal set; get; }
        [DataMember(Name = "name")]
        public string Name { internal set; get; }
        [DataMember(Name = "profile_image_url_https")]
        public string ProfileImageUrl { internal set; get; }
        [DataMember(Name = "cover_image_url_https")]
        public string CoverImageUrl { internal set; get; }
        [DataMember(Name = "protected")]
        public bool IsProtected { internal set; get; }
        [DataMember(Name = "screen_name")]
        public string ScreenName { internal set; get; }
        [DataMember(Name = "statuses_count")]
        public string StatusesCount { internal set; get; }
        [DataMember(Name = "url")]
        public string Url { internal set; get; }

    }
}
