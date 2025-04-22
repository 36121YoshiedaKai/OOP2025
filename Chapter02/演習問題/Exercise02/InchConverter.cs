using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    class InchConverter
    {
        //定数
        private const double ratio = 0.0254;

        //インチからメートルへ計算
        public static double ToInch(double Inch) {
            return Inch * ratio;
        }


    }
}
