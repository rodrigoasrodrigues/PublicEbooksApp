using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using PublicDomainEbooks.Authentication;
using PublicDomainEbooks.iOS.Authentication;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace PublicDomainEbooks.iOS.Authentication
{
    public class SocialAuthentication : IAuthentication

    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(GetController(), provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? String.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
                //TODO: Log Error
                throw;
            }
        }
        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            if (root == null) return null;

            var current = root;

            while(current.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }

            return current;
        }
    }
}
