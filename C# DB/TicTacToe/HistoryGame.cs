using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    public class HistoryGame
    {
        public int Id { get; set; }
        public string FirstPlayer { get; set; }
        public string SecondPlayer { get; set; }
        public string Status { get; set; }
        public string WinnerOrDraw { get; set; }
    }
}
