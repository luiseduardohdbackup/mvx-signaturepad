using System;
using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using System.Collections.Generic;


namespace Acr.MvvmCross.Plugins.SignaturePad.Droid {
    
    public class DroidSignatureService : AbstractSignatureService {

        internal static IEnumerable<DrawPoint> CurrentPoints { get; private set; }
        internal static SignaturePadConfiguration CurrentConfig { get; private set; }
        internal static Action<SignatureResult> OnResult { get; private set; }


        protected override void GetSignature(Action<SignatureResult> onResult, SignaturePadConfiguration cfg) { 
            CurrentPoints = null;
            CurrentConfig = cfg;
            OnResult = onResult;
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            topActivity.StartActivity(typeof(SignaturePadActivity));
        }


        protected override void Load(IEnumerable<DrawPoint> points, SignaturePadConfiguration cfg) {
            CurrentConfig = cfg;
            CurrentPoints = points;
            OnResult = null;
        }
    }
}