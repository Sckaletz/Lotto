using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Lotto
{
    public class RowsGenerator
    {
        public int Rows = 10;
        public int NumOnRow = 7;
        private int JokerRows = 2;
        private int JokerNumOnRow = 7;

        public int[] GenerateRow()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<int> tmpNumList = new List<int>();
            int[] kuponRow = new int[NumOnRow];
            int tmp;
            for (int i = 0; i < NumOnRow; i++)
            {
                tmp = random.Next(1, 37);
                while (tmpNumList.Contains(tmp) == true)
                {
                    tmp = random.Next(1, 37);
                }
                if (tmpNumList.Contains(tmp) != true)
                {
                    kuponRow[i] = tmp;
                    tmpNumList.Add(tmp);
                }
            }
            return kuponRow;
        }

        public int[][] GenerateRowsTilKupon()
        {
            List<int[]> tmpRowslist = new List<int[]>();
            int[][] allRows = new int[Rows][];
            for (int i = 0; i < Rows; i++)
            {
                int[] tmp = GenerateRow();
                Array.Sort(tmp);
                while (tmpRowslist.Contains(tmp) == true)
                {
                    tmp = GenerateRow();
                }
                if (tmpRowslist.Contains(tmp) != true)
                {
                    allRows[i] = tmp;
                    tmpRowslist.Add(tmp);
                }
            }
            return allRows;
        }

        public int[] JokerRowGenerator()
        {
            Random random2 = new Random(Guid.NewGuid().GetHashCode());
            int[] jokerKuponRow = new int[JokerNumOnRow];
            int tmp;
            for (int i = 0; i < JokerNumOnRow; i++)
            {
                tmp = random2.Next(1, 10);
                jokerKuponRow[i] = tmp;
            }
            return jokerKuponRow;
        }

        public int[][] GenerateJokerRowsTilKupon()
        {
            List<int[]> tmpJokerRowsList = new List<int[]>();
            int[][] allJokerRows = new int[JokerRows][];
            for (int i = 0; i < JokerRows; i++)
            {
                int[] tmp = JokerRowGenerator();
                while (tmpJokerRowsList.Contains(tmp) == true)
                {
                    tmp = JokerRowGenerator();
                }
                if (tmpJokerRowsList.Contains(tmp) != true)
                {
                    allJokerRows[i] = tmp;
                    tmpJokerRowsList.Add(tmp);
                }
            }
            return allJokerRows;
        }
    }
}
