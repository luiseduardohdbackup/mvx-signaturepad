using System;
using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;


namespace Acr.MvvmCross.Plugins.SignaturePad.Droid {
    
    public class DroidSignatureService : AbstractSignatureService {
        internal static PadConfiguration CurrentConfig;
        internal static Action<SignatureResult> OnSave;
        internal static Action OnCancel;


        protected override void GetSignature(Action<SignatureResult> onSave, Action onCancel, PadConfiguration cfg) {            
            CurrentConfig = cfg;
            OnSave = onSave;
            OnCancel = onCancel;
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            topActivity.StartActivity(typeof(SignaturePadActivity));
        }
    }
}