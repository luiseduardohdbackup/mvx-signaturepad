using System;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Sample.Core.ViewModels;


namespace Sample.Touch.Views {

    [Register("HomeView")]
    public class HomeView : MvxTableViewController {

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            this.Title = "MVX Signatures";

            var btnAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            var btnConfig = new UIBarButtonItem(UIBarButtonSystemItem.Edit);
            this.NavigationItem.RightBarButtonItems = new [] { btnAdd, btnConfig };

            var src = new MvxStandardTableViewSource(this.TableView, "TitleText FileName");

            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(src).To(x => x.List);
            set.Bind(src).For(x => x.SelectionChangedCommand).To(x => x.View);
            set.Bind(btnAdd).To(x => x.Create);
            set.Bind(btnConfig).To(x => x.Configure);
            set.Apply();

            this.TableView.Source = src;
            this.TableView.ReloadData();
        }
    }
}



