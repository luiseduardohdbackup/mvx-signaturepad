using System;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.ViewModels;


namespace Sample.Core {

    public class App : MvxApplication {

        public App() {
            
            this.RegisterAppStart<DemoViewModel>();
        }


        public override void LoadPlugins(IMvxPluginManager pluginManager) {
            base.LoadPlugins(pluginManager);
            pluginManager.EnsurePlatformAdaptionLoaded<Acr.MvvmCross.Plugins.SignaturePad.PluginLoader>();
        }
    }
}
