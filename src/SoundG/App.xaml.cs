using System.Windows;

namespace SoundG {
    public partial class App {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            new Bootstrapper().Run();
        }
    }
}