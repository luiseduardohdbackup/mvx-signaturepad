using System;
using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;



namespace Sample.Droid.Views {

    [Activity]      
    public class ConfigurationActivity : MvxActivity {

        protected override void OnViewModelSet() {
            base.OnViewModelSet();
            this.SetContentView(Resource.Layout.Configuration);
        }
    }
}

