using System;
using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;

using SignaturePad;


namespace Acr.MvvmCross.Plugins.SignaturePad.Droid {
    
    public class DroidSignatureService : AbstractSignatureService {
        internal static PadConfiguration CurrentConfig;
        internal static Action<Stream> OnSave;
        internal static Action OnCancel;


        protected override void GetSignature(Action<Stream> onSave, Action onCancel, PadConfiguration cfg) {
            CurrentConfig = cfg;
            OnSave = onSave;
            OnCancel = onCancel;
            var globals = Mvx.Resolve<IMvxAndroidGlobals>();
            globals.ApplicationContext.StartActivity(typeof(SignaturePadActivity));
        }
    }
}