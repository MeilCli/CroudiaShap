using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using CroudiaSharp.Http;
using CroudiaSharp.REST;
using System.Net.Http;
using System.IO;

namespace CroudiaSharp {
    [DataContract]
    public class Token {

        internal Token() { }

        public Token(string consumerKey,string consumerSecret,Config config)
            : this(consumerKey,consumerSecret,null,null,null,DateTime.UtcNow,config) {
        }

        public Token(string consumerKey,string consumerSecret,string accessToken,string refreshToken,string tokenType,Config config)
            : this(consumerKey,consumerSecret,accessToken,refreshToken,tokenType,DateTime.UtcNow,config) {
        }

        public Token(string consumerKey,string consumerSecret,string accessToken,string refreshToken,string tokenType,DateTime expiresIn,Config config) {
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.TokenType = tokenType;
            this.ExpiresIn = expiresIn;
            this.Http = new HttpHelper();
            this.Config = config ?? new Config();
            this.Oauth = new Oauth(this);
            this.Account = new Account(this);
            this.Statuses = new Statuses(this);
            this.SecretMails = new SecretMails(this);
            this.Friendships = new Friendships(this);
        }

        public string ConsumerKey { internal set; get; }
        public string ConsumerSecret { internal set; get; }
        [DataMember(Name = "access_token")]
        public string AccessToken { internal set; get; }
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { internal set; get; }
        [DataMember(Name = "token_type")]
        public string TokenType { internal set; get; }

        int _expriresIn;
        [DataMember(Name = "expires_in")]
        internal int SetExpiresIn {
            set {
                _expriresIn = value;
                DateTime now = DateTime.Now;
                this.ExpiresIn = now.AddSeconds(value);
            }
            get { return _expriresIn; }
        }
        public DateTime ExpiresIn { internal set; get; }

        internal HttpHelper Http { private set; get; }
        public Config Config { internal set; get; }
        public Oauth Oauth { private set; get; }
        public Account Account { private set; get; }
        public Statuses Statuses { private set; get; }
        public SecretMails SecretMails { private set; get; }
        public Friendships Friendships { private set; get; }

        public override string ToString() {
            return "ConsumerKey : "+ConsumerKey+" ConsumerSecret : "+ConsumerSecret+" AccessToken : "+AccessToken+" RefreshToken : "+RefreshToken+" ExpiresIn : "+ExpiresIn.ToString();
        }

    }
}
