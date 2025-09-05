using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorChecker {
    public struct MyColor {
        public Color Color { get; set; }
        public String Name { get; set; }
        public override string ToString() {
            return string.IsNullOrEmpty(Name)? $"R:{Color.R}, G:{Color.G}, B:{Color.B}": Name;
        }
    }
}
