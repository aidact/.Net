using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levenstein
{
    public class Levenstein
    {
        public static int Distance(string original, string modified) // two input strings
        {
            int origLen = original.Length;
            int diffLen = modified.Length;

            var matrix = new int[origLen + 1, diffLen + 1];

            for (int i=0; i<=origLen; i++)
                matrix[i, 0] = i;
            for (int j=0; j<=diffLen; j++)
                matrix[0, j] = j;

            for (int i=1; i<=origLen; i++)
            {
                for (int j=1; j<=diffLen; j++)
                {
                    int cost = modified[j - 1] == original[i - 1] ? 0 : 1;
                    var vals = new int[] {
					matrix[i - 1, j] + 1,
					matrix[i, j - 1] + 1,
					matrix[i - 1, j - 1] + cost
				};
                    matrix[i, j] = vals.Min();
                    if (i>1 && j>1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }
            return matrix[origLen, diffLen];
        }
    }
}
