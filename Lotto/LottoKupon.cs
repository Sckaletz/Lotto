using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class LottoKupon
    {
        public string TimeStamp;
        public string Week = "1 uge";
        public string Title = "LYN LOTTO";
        public int[][] Rows;
        public int[][] JokerRows;

        public LottoKupon(string timeStamp, int[][] rowNum)
        {
            this.TimeStamp = timeStamp;
            this.Rows = rowNum;
            var empty = new int[0][];
            this.JokerRows= empty;
        }

        public LottoKupon(string timestamp, int[][] rowNum, int[][] joker)
        {
            this.TimeStamp = timestamp;
            this.Rows = rowNum;
            this.JokerRows = joker;
        }
    }
}
