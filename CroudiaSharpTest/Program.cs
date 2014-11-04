using CroudiaSharp;
using CroudiaSharp.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharpTest {
    public class Program {
        public const string ConsumerKey = "";
        public const string ConsumerSecret = "";
        public const string Dir = @"";
        public const string Image = Dir+@"\TestIcon.png";
        
        public static void Main(string[] args) {
            Token token = new Token(ConsumerKey,ConsumerSecret,new Config() { IsLog=true});
            Console.Out.WriteLine("URLで認証してCallbackURLを入力してください");
            Console.Out.WriteLine(token.Oauth.Authorize());
            string callback = Console.In.ReadLine();
            token.Oauth.Token(callback);
            Console.Out.WriteLine("GetAccessToken");
            Console.Out.WriteLine(token.ToString());
            token.Oauth.Token();
            Console.Out.WriteLine("RefreshAccessToken");
            Console.Out.WriteLine(token.ToString());
            var user = token.Account.VerifyCredentials();
            Console.Out.WriteLine(user.ScreenName+" "+user.CreatedAt.ToString());
            //token.Account.UpdateProfileImage(Image);
            //token.Account.UpdateCoverImage(Image);
            //token.Account.UpdateProfile(location=>"jap");
            //token.Statuses.PublicTimeLine(new Dictionary<string,object>() { { "count",10 } }).ForEach(x=>Console.Out.WriteLine(x.User.ScreenName+" : "+x.Text));
            //token.Statuses.Update(status => "API call test");
            //token.Statuses.UpdateWithMedia(status => "test",media => Image);
            //token.SecretMails.Get().ForEach(x => Console.Out.WriteLine(x.SenderUser.ScreenName + " : " + x.Text));
            //foreach(SecretMail sm in token.SecretMails.Get().Where(x => x.Entities != null&&x.Entities.Media!=null)) {
            //    var img = token.SecretMails.GetSecretPhoto(sm.Entities.Media.Id);
            //    img.Save(Dir + @"\secret_photo.png");
            //}
            while(true) {
                Console.In.ReadLine();
            }
        }


    }
}
