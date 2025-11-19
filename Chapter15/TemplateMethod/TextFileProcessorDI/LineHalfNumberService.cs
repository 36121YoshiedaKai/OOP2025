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
                if ('０'<= c && c <= '９') {
                    _sb.Append((char)(c - '０' + '0'));
                } else {
                    _sb.Append(c);
                }
            }
            _sb.AppendLine();
        }

        public void Terminate() {
            Console.WriteLine(_sb.ToString());
        }
    }
}
