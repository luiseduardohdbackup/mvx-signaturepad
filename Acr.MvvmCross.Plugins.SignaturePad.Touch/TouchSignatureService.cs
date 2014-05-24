using System;
using System.IO;
using SignaturePad;
using MonoTouch.UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views.Presenters;


namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {
    
    public class TouchSignatureService : AbstractSignatureService {

        protected override void GetSignature(Action<SignatureResult> onSave, Action onCancel, PadConfiguration cfg) {
            var presenter = Mvx.Resolve<IMvxTouchViewPresenter>();
            var signature = new SignatureViewController(cfg, onSave, onCancel);
            presenter.PresentModalViewController(signature, true);
        }
    }
}