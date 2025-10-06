using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrismObservesSample {
    class MainWindowViewModel : BindableBase {
        private string _input1 = "";
        public string Input1 {
            get => _input1;
            set => SetProperty(ref _input1 , value );
        }

        private string _input2 = "";
        public string Input2 {
            get => _input2;
            set => SetProperty(ref _input2 , value);
        }

        private string _result = "";
        public string Result {
            get => _result;
            set => SetProperty(ref _result , value);
        }

        //コンストラクタ
        public MainWindowViewModel() {
            SumCommand = new DelegateCommand(ExecuteSum);
        }

        //足し算の処理
        private void ExecuteSum() {
            if (int.TryParse(Input1,out int i1) && int.TryParse(Input2, out int i2)) {
                Result = (i1 + i2).ToString();
            } 
        }

        public DelegateCommand SumCommand { get; }
    }
}
