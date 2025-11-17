using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public class MeterConverter : ConverterBase {

        public override bool IsNyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;

        protected override double Ratio => 1;

        public override string UnitName => "メートル";

    }

    public class FeetConverter : ConverterBase {

        public override bool IsNyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;

        protected override double Ratio => 0.3048;

        public override string UnitName => "フィート";

    }

    public class InchConverter : ConverterBase {

        public override bool IsNyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;

        protected override double Ratio => 0.0254;

        public override string UnitName => "インチ";

    }

    public class YardConverter : ConverterBase {

        public override bool IsNyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;

        protected override double Ratio => 0.9144;

        public override string UnitName => "ヤード";

    }

    public class MileConverter : ConverterBase {

        public override bool IsNyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;

        protected override double Ratio => 1609.34;

        public override string UnitName => "マイル";

    }

    public class KmeterConverter : ConverterBase {

        public override bool IsNyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;

        protected override double Ratio => 1000;

        public override string UnitName => "キロメートル";

    }

}
