using System;
using Acr.MvvmCross.Plugins.SignaturePad;
using Cirrious.MvvmCross.ViewModels;
using System.Runtime.CompilerServices;


namespace Sample.Core {
    
    public class ConfigurationViewModel : MvxViewModel {
        private readonly ISignatureService signatureService;


        public ConfigurationViewModel(ISignatureService signatureService) {
            this.signatureService = signatureService;
        }


        protected virtual bool SetPropertyChange<T>(ref T property, T value, [CallerMemberName] string propertyName = null){
            if (Object.Equals(property, value)) 
                return false;

            property = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }


        protected virtual void FirePropertyChanged([CallerMemberName] string propertyName = null) {
            this.RaisePropertyChanged(propertyName);
        }


        public string CancelText {
            get { return this.signatureService.DefaultConfiguration.CancelText; }
            set { 
                var a = this.signatureService.DefaultConfiguration;
                if (a.CancelText == value)
                    return;

                a.CancelText = value;
                this.FirePropertyChanged();
            }
        }


        public string SaveText {
            get { return this.signatureService.DefaultConfiguration.SaveText; }
            set { 
                var a = this.signatureService.DefaultConfiguration;
                if (a.SaveText == value)
                    return;

                a.SaveText = value;
                this.FirePropertyChanged();
            }
        }
    }
}
