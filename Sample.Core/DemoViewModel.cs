using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Acr.MvvmCross.Plugins.SignaturePad;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.ViewModels;


namespace Sample.Core {
    
    public class DemoViewModel : MvxViewModel {

        // TODO: clear all signatures
        // TODO: display signature image
        private readonly ISignatureService signatureService;
        private readonly IMvxFileStore fileStore;


        public DemoViewModel(ISignatureService signatureService, IMvxFileStore fileStore) {
            this.signatureService = signatureService;
            this.fileStore = fileStore;

            this.Photos = new ObservableCollection<Photo>(
                this.fileStore
                    .GetFilesIn(this.fileStore.NativePath(""))
                    .Select(x => new Photo {
                        FileName = x
                    })
            );
        }

        #region Bindings

        public ObservableCollection<Photo> Photos { get; private set; } 

        public IMvxCommand Request {
            get {
                // TODO: configure colours
                return new MvxCommand(() => this.signatureService.RequestSignature(this.OnSigature, this.OnCancel));   
            }
        }

        #endregion

        #region Internals

        private void OnSigature(Stream stream) {
            var fileName = String.Format("{0:YYYY MMMM DD hh:ss", DateTime.Now);
            this.fileStore.WriteFile(fileName, stream.CopyTo);
            this.Photos.Add(new Photo {
                FileName = fileName
            });
        }


        private void OnCancel() {

        }

        #endregion
    }
}
