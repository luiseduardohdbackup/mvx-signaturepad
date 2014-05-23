using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Plugins.File;
using Acr.MvvmCross.Plugins.SignaturePad;
using Sample.Core.Models;


namespace Sample.Core.ViewModels {

    public class HomeViewModel : MvxViewModel {

        private const string FILE_FORMAT = "{0:dd-MM-yyyy hh:mm:ss tt}.jpg";
        private readonly IMvxFileStore store;
        private readonly ISignatureService signatureService;


        public HomeViewModel(IMvxFileStore store, ISignatureService signatureService) {
            this.store = store;
            this.Create = new MvxCommand(this.OnCreate);
            this.Delete = new MvxCommand<Signature>(this.OnDelete);
            this.View = new MvxCommand<Signature>(this.OnView);
        }


        public override void Start() {
            base.Start();
            var files = this.store
                .GetFilesIn(".")
                .ToList();

            foreach (var file in files) 
                this.List.Add(new Signature { FileName = file });
        }


        public ObservableCollection<Signature> List { get; private set; }
        public IMvxCommand Create { get; private set; }
        public MvxCommand<Signature> View { get; private set; }
        public MvxCommand<Signature> Delete { get; private set; }


        private void OnCreate() {
            this.signatureService.RequestSignature(stream => {
                var fileName = String.Format(FILE_FORMAT, DateTime.Now);
                var path = this.store.NativePath(fileName);

                using (var ms = new MemoryStream()) {
                    stream.CopyTo(ms);
                    var bytes = ms.ToArray();
                    this.store.WriteFile(path, bytes);
                }
                this.List.Add(new Signature {
                    FileName = fileName
                });
            });      
        }


        private void OnView(Signature signature) {
            var path = this.store.NativePath(signature.FileName);
            // TODO: open
        }


        private void OnDelete(Signature signature) {
            var path = this.store.NativePath(signature.FileName);
            this.store.DeleteFile(path);
            this.List.Remove(signature);
        }
    }
}

