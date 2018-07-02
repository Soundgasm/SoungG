using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using SoundG.Controllers;
using SoundG.Models;

namespace SoundG.ViewModels {
    internal class ShellViewModel : BindableBase {
        private ObservableCollection<Sound> sounds;
        private string title;

        public ShellViewModel() {
            Title = "SoundG";
            List<Sound> list = new SoundController("https://soundgasm.net/u/alwaysslightlysleepy").GetSounds();
            Sounds = new ObservableCollection<Sound>(list);
        }

        public string Title {
            get => title;
            set => SetProperty(ref title, value);
        }

        public ObservableCollection<Sound> Sounds {
            get => sounds;
            set => SetProperty(ref sounds, value);
        }
    }
}