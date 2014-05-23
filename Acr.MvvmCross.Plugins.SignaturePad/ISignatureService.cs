using System;
using System.IO;


namespace Acr.MvvmCross.Plugins.SignaturePad {
    
    public interface ISignatureService {

        PadConfiguration DefaultConfiguration { get; }
        void RequestSignature(Action<Stream> onSave, Action onCancel = null, PadConfiguration cfg = null);
    }
}
