using System;

namespace DctTransform
{
    public class DctTransfrom
    {
        private const int M = 8, N = 8;

        public float[,] ResolveDct(int[,] matrix)
        {
            int i;
            var dct = new float[M, N];

            for (i = 0; i < M; i++)
            {
                int j;
                for (j = 0; j < N; j++)
                {
                    var ci = i == 0 ? Convert.ToSingle(1 / Math.Sqrt(M)) : Convert.ToSingle(Math.Sqrt((2) / Math.Sqrt((M))));
                    var cj = j == 0 ? Convert.ToSingle(1 / Math.Sqrt((Convert.ToDouble(N)))) : Convert.ToSingle(Math.Sqrt((2) / Math.Sqrt((Convert.ToDouble(N)))));

                    float sum = 0;
                    int k;
                    for (k = 0; k < M; k++)
                    {
                        int l;
                        for (l = 0; l < N; l++)
                        {
                            var dct1 = Convert.ToSingle(matrix[k, l] *
                                                        Math.Cos((2 * k + 1) * i * Math.PI / (2 * M)) *
                                                        Math.Cos((2 * l + 1) * j * Math.PI / (2 * N)));
                            sum = sum + dct1;
                        }
                    }

                    dct[i, j] = ci * cj * sum;
                }
            }
            return dct;
        }
    }
}
