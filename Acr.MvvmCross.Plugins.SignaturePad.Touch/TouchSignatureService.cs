using System;
using System.IO;
using SignaturePad;


namespace Acr.MvvmCross.Plugins.SignaturePad.Touch {
    
    public class TouchSignatureService : AbstractSignatureService {

        protected override void GetSignature(Action<SignatureResult> onSave, Action onCancel, PadConfiguration cfg) {
            var signature = new SignaturePadView();
                //StrokeColor = Co
                //SignatureLineColor = 
            //signature.SignatureLineColor = Color
            //signature.BackgroundColor
            //signature.StrokeColor
            //signature.StrokeWidth
            //signature.Caption.Text
            //signature.Caption.CurrentTextColor
            //signature.SignaturePrompt.Text
            //signature.SignaturePrompt.CurrentTextColor

            // save text
            // cancel text (if available)
//            using (var image = signature.GetImage()) {
//                // TODO: to stream
//            }
        }
    }
}