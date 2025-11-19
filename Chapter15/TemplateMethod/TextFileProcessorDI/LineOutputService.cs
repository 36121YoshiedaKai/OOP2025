using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class LineOutputService :ITextFileService {
        private int _count;
        private StringBuilder _sb;

        public void Initialize(string fname) {
            _count = 0;
            _sb = new StringBuilder();
        }

        public void Execute(string line) {
            _count++;
            if (_count <= 20) {
                _sb.AppendLine(line);
            }
        }

        public void Terminate() {
            Console.WriteLine(_sb.ToString());
        }
    }
}
