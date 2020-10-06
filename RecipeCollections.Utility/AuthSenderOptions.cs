using System;

namespace RecipeCollections.Utility {
    public class AuthSenderOptions {
        private readonly string user = "Gradner Recipe Collections"; // The name you want to show up on your email
                                               // Make sure the string passed in below matches your API Key
        private readonly string key = Environment.GetEnvironmentVariable("SENDGRID");
        public string SendGridUser { get { return user; } }
        public string SendGridKey { get { return key; } }
    }
}
