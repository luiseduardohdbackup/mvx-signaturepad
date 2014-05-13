using System;
using Acr.MvvmCross.Plugins.SignaturePad;
using Cirrious.MvvmCross.ViewModels;


namespace Sample.Core {
    
    public class ConfigurationViewModel : MvxViewModel {
        private readonly ISignatureService signatureService;


        public ConfigurationViewModel(ISignatureService signatureService) {
            this.signatureService = signatureService;    
        }
    }
}
