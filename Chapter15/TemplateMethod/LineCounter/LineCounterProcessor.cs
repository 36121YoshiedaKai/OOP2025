using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;
        private string _text = "private";

        protected override void Initialize(string fname) => _count = 0;

        protected override void Execute(string line) {
            if (line.Contains(_text)) {
                _count++;
            }
        }

        protected override void Terminate() => Console.WriteLine("Priveteは {0}個", _count);
    }

}
