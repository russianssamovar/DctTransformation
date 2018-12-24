using System;
using System.Linq;

namespace DctTransformation
{
    public class DctTransfrom
    {
        public static void Dct(double[] data)
        {
            var result = new double[data.Length];
            var c = Math.PI / (2.0 * data.Length);
            var scale = Math.Sqrt(2.0 / data.Length);

            for (var k = 0; k < data.Length; k++)
            {
                var sum = data.Select((t, n) => t * Math.Cos((2.0 * n + 1.0) * k * c)).Sum();
                result[k] = scale * sum;
            }

            data[0] = result[0] / Math.Sqrt(2);
            for (var i = 1; i < data.Length; i++)
                data[i] = result[i];
        }

        public static void Dct(double[,] data)
        {
            var rows = data.GetLength(0);
            var cols = data.GetLength(1);

            var row = new double[cols];
            var col = new double[rows];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < row.Length; j++)
                    row[j] = data[i, j];

                Dct(row);

                for (var j = 0; j < row.Length; j++)
                    data[i, j] = row[j];
            }

            for (var j = 0; j < cols; j++)
            {
                for (var i = 0; i < col.Length; i++)
                    col[i] = data[i, j];

                Dct(col);

                for (var i = 0; i < col.Length; i++)
                    data[i, j] = col[i];
            }
        }

        public static void Idct(double[] data)
        {
            var result = new double[data.Length];
            var c = Math.PI / (2.0 * data.Length);
            var scale = Math.Sqrt(2.0 / data.Length);

            for (var k = 0; k < data.Length; k++)
            {
                var sum = data[0] / Math.Sqrt(2);
                for (var n = 1; n < data.Length; n++)
                    sum += data[n] * Math.Cos((2 * k + 1) * n * c);

                result[k] = scale * sum;
            }

            for (var i = 0; i < data.Length; i++)
                data[i] = result[i];
        }

        public static void Idct(double[,] data)
        {
            var rows = data.GetLength(0);
            var cols = data.GetLength(1);

            var row = new double[cols];
            var col = new double[rows];

            for (var j = 0; j < cols; j++)
            {
                for (var i = 0; i < row.Length; i++)
                    col[i] = data[i, j];

                Idct(col);

                for (var i = 0; i < col.Length; i++)
                    data[i, j] = col[i];
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < row.Length; j++)
                    row[j] = data[i, j];

                Idct(row);

                for (var j = 0; j < row.Length; j++)
                    data[i, j] = row[j];
            }
        }
    }
}
