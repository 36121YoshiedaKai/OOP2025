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
        private string _text = "";

        protected override void Initialize(string fname) {
            _count = 0;
            Console.Write("カウントしたい単語:");
            _text = Console.ReadLine();
        }

        protected override void Execute(string line) {
            int index = 0;

            if (string.IsNullOrWhiteSpace(_text)) {
                Console.WriteLine("デフォルトはaです");
                _text = "a";
            }

            while ((index = line.IndexOf(_text, index, StringComparison.OrdinalIgnoreCase)) != -1) {
                _count++;
                index++;
            }
        }

        protected override void Terminate() => Console.WriteLine($"{_text}は {_count}個");
    }

}
