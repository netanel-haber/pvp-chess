using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess___netanel
{
    class ThreatsPackage
    {
        public List<SingleThreatPackage> LineOfSightThreats { get; set; }
        public SingleThreatPackage KnightCheck { get; set; }
        public bool IsDoubleCheck
        {
            get
            {
                if (LineOfSightThreats == null)
                    return false;
                if (LineOfSightThreats.Count == 2)
                    return true;
                if (LineOfSightThreats.Count == 1 && KnightCheck != null)
                    return true;
                return false;
            }
        }
        public bool isCheck
        {
            get
            {
                return ((LineOfSightThreats!=null)||(KnightCheck!=null));
            }
        }

    }
}
