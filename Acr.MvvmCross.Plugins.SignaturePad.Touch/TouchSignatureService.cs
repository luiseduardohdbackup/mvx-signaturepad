using System;
using System.IO;
using System.Collections.Generic;
using SignaturePad;
using MonoTouch.UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views.Presenters;


namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {
    
    public class TouchSignatureService : AbstractSignatureService {

        protected override void GetSignature(Action<SignatureResult> onResult, SignaturePadConfiguration cfg) {
            var controller = new MvxSignatureController(cfg, onResult);
            this.Show(controller);
        }


        protected override void Load(IEnumerable<DrawPoint> points, SignaturePadConfiguration cfg) {
            var controller = new MvxSignatureController(cfg, points);
            this.Show(controller);
        }


        private void Show(MvxSignatureController controller) {
            var presenter = Mvx.Resolve<IMvxTouchViewPresenter>();
            presenter.PresentModalViewController(controller, true);
        }
    }
}