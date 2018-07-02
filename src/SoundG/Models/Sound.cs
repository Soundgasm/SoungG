using System;
using Prism.Mvvm;

namespace SoundG.Models {
    internal class Sound : BindableBase {
        private string description;

        private uint id;
        private uint playCount;
        private string title;
        private Uri url;
        
        public uint Id {
            get => id;
            set => SetProperty(ref id, value);
        }

        public uint PlayCount {
            get => playCount;
            set => SetProperty(ref playCount, value);
        }

        public string Title {
            get => title;
            set => SetProperty(ref title, value);
        }

        public Uri Url {
            get => url;
            set => SetProperty(ref url, value);
        }

        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }
    }
}