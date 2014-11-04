using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp {
    internal static class APIConstant {
        private const string Base = "https://api.croudia.com";
        
        public const string OauthAuthorize = Base+"/oauth/authorize";
        public const string OauthToken = Base + "/oauth/token";

        public const string AccountVerifyCredentials = Base + "/account/verify_credentials.json";
        public const string AccountUpdateProfileImage = Base + "/account/update_profile_image.json";
        public const string AccountUpdateCoverImage = Base + "/account/update_cover_image.json";
        public const string AccountUpdateProfile = Base + "/account/update_profile.json";

        public const string StatusesPublicTimeline = Base + "/statuses/public_timeline.json";
        public const string StatusesHomeTimeline = Base + "/statuses/home_timeline.json";
        public const string StatusesUserTimeline = Base + "/statuses/user_timeline.json";
        public const string StatusesMentions = Base + "/statuses/mentions.json";
        public const string StatusesUpdate = Base + "/statuses/update.json";
        public const string StatusesUpdateWithMedia = Base + "/statuses/update_with_media.json";
        public const string StatusesDestroy = Base + "/statuses/destroy/";
        public const string StatusesShow = Base + "/statuses/show/";
        public const string StatusesSpread = Base + "/statuses/spread/";
        public const string StatusesShare = Base + "/statuses/share.json";
        public const string StatusesShareWithMedia = Base + "/statuses/share_with_media.json";

        public const string SecretMailsGet = Base + "/secret_mails.json";
        public const string SecretMailsSent = Base + "/secret_mails/sent.json";
        public const string SecretMailsNew = Base + "/secret_mails/new.json";
        public const string SecretMailsNewWithMedia = Base + "/secret_mails/new_with_media.json";
        public const string SecretMailsDestroy = Base + "/secret_mails/destroy/";
        public const string SecretMailsShow = Base + "/secret_mails/show/";
        public const string SecretMailsGetSecretPhoto = Base + "/secret_mails/get_secret_photo/";

        public const string UsersShow = Base + "/users/show.json";
        public const string UsersLookUp = Base + "/users/lookup.json";
        public const string UsersSearch = Base + "/users/search.json";

        public const string FriendshipsCreate = Base + "/friendships/create.json";
        public const string FriendshipsDestroy = Base + "/friendships/destroy.json";
        public const string FriendshipsShow = Base + "/friendships/show.json";

    }
}
