using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess___netanel
{
    class SingleThreatPackage
    {
        public ChessPiece threateningPiece { get; set; }
        public List<Point> pointsOfThreats { get; set; }
        public bool isDiagonalThreat { get; set; }
        public bool isThreateningPieceKnight { get; set; }
    }
}
