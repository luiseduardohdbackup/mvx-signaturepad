using System;
using System.IO;


namespace Acr.MvvmCross.Plugins.SignaturePad {
    
    public interface ISignatureService {

        PadConfiguration DefaultConfiguration { get; set; }
        void RequestSignature(Action<Stream> onSigned, Action cancelAction = null, PadConfiguration configuration = null);
    }
}
