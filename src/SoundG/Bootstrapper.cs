using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using SoundG.Views;

namespace SoundG {
    internal class Bootstrapper : UnityBootstrapper {
        protected override DependencyObject CreateShell() {
            return Container.Resolve<ShellView>();
        }

        protected override void InitializeShell() {
            Application.Current.MainWindow?.Show();
        }
    }
}