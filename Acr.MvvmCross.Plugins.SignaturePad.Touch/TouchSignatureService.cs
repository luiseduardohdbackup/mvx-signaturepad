using System;
using System.IO;
using SignaturePad;
using MonoTouch.UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views.Presenters;


namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {
    
    public class TouchSignatureService : AbstractSignatureService {

        protected override void GetSignature(Action<SignatureResult> onResult, PadConfiguration cfg) {
            var presenter = Mvx.Resolve<IMvxTouchViewPresenter>();
            var signature = new MvxSignatureController(cfg, onResult);
            presenter.PresentModalViewController(signature, true);
        }


//        public override void LoadSignature(params DrawPoint[] points) {
//        }
    }
}