using System;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.Dialog.Touch;
using Cirrious.MvvmCross.Binding.BindingContext;
using CrossUI.Touch.Dialog.Elements;
using Sample.Core.ViewModels;
using Sample.Core;


namespace Sample.Touch.Views {

    [Register("ConfigurationView")]
    public class ConfigurationView : MvxDialogViewController {

        public ConfigurationView() : base(pushing: true) { }


        public override void ViewDidLoad() {
            base.ViewDidLoad();
            var bindings = this.CreateInlineBindingTarget<ConfigurationViewModel>();

            this.Root = new RootElement("Configuration") {
                new Section("Button Text") {
                    new StringElement("Save").Bind(bindings, x => x.Value, x => x.SaveText),
                    new StringElement("Cancel").Bind(bindings, x => x.Value, x => x.CancelText)
                },
                new Section("Colors") {
                }
            };
        }
    }
}