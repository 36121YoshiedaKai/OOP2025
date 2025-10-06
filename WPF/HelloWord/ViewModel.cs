using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord {

    class ViewModel : BindableBase {
        public ViewModel() {
            ChangeMessageCommand = new DelegateCommand<string>(
                (par) => GreetingMessage = par,
                (par) => GreetingMessage != par)
                .ObservesProperty(() => GreetingMessage);

        }

        private string _greetingMessage = "Hello World!!!!!";

        public string GreetingMessage {
            get => _greetingMessage;
            set => SetProperty(ref _greetingMessage, value);
        }

        //private bool _canChangeMessage = true;
        //public bool CanChangeMessage {
        //    get => _canChangeMessage;
        //    private set => SetProperty(ref _canChangeMessage, value);
        //}

        public string NewMessage1 { get; } = "Bey-bey world";
        public string NewMessage2 { get; } = "Long time no see, world";
        public DelegateCommand<string> ChangeMessageCommand { get; }
    }
}