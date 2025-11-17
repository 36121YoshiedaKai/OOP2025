using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public abstract class ConverterBase {

        public abstract bool IsNyUnit(string name);

        //メートルとの比率
        protected abstract double Ratio { get ; }
        //飛距離の単位名
        public abstract string UnitName { get; }
        //メートルからの変換
        public double FromMeter(double meter) => meter/Ratio;
        //メートルへの変換
        public double ToMeter(double feet) => feet * Ratio;
        

    }
}
