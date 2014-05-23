using System;
using Android.Content;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Sample.Core;


namespace Sample.Droid {

    public class Setup : MvxAndroidSetup {

        public Setup(Context appContext) : base(appContext) { }


        protected override IMvxApplication CreateApp() {
            return new App();
        }
    }
}