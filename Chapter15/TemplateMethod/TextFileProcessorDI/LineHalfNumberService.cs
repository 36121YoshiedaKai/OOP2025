using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class LineHalfNumberService :ITextFileService{
        
        private StringBuilder _sb;

        public void Initialize(string fname) {
            _sb = new StringBuilder();
        }

        public void Execute(string line) {
            foreach (char c in line) {
                switch (c) {
                    case '０':
                        _sb.Append('0');
                        break;
                    case '１':
                        _sb.Append('1');
                        break;
                    case '２':
                        _sb.Append('2');
                        break;
                    case '３':
                        _sb.Append('3');
                        break;
                    case '４':
                        _sb.Append('4');
                        break;
                    case '５':
                        _sb.Append('5');
                        break;
                    case '６':
                        _sb.Append('6');
                        break;
                    case '７':
                        _sb.Append('7');
                        break;
                    case '８':
                        _sb.Append('8');
                        break;
                    case '９':
                        _sb.Append('9');
                        break;
                    default:
                        _sb.Append(c);
                        break;
                }
            }
            _sb.AppendLine();
        }

        public void Terminate() {
            Console.WriteLine(_sb.ToString());
        }
    }
}
