using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class TextFileProcessor {
        private ITextFileService _serivce;

        //コンストラクタ
        public TextFileProcessor(ITextFileService serivce) {
            _serivce = serivce;
        }

        public void Run(string fileName) {
            _serivce.Initialize(fileName);

            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines) {
                _serivce.Execute(line);
            }
            _serivce.Terminate();
        }
    }
}
