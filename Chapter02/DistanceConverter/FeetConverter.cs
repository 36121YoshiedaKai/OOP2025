using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    public class FeetConverter
    {
        //メートルからフィートを求める
        static double FromMeter(double meter) {
            return meter / 0.3048;
        }

        //フィートからメートルを求める
        static double FromFeet(double feet) {
            return feet * 0.3048;
        }

    }
}
