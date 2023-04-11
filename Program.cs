namespace Console_Practice2
{
    using System.Text;
    internal class Program
    {
        static void Main(string[] args)
        {
                double[,] d = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };  // Test constructor
                Matrix m = new Matrix(d);
                Console.WriteLine(m.ToString());

                Console.WriteLine("----------------");

                Matrix m_res = new Matrix(2, 2);                          // Test properties
                m_res[0, 0] = 5;
                m_res[0, 1] = 5;
                Console.WriteLine(m_res.ToString());

                Console.WriteLine("----------------");

                Matrix m1 = new Matrix(2, 2);                             // Test properties (Rows,Columns)
            Console.WriteLine(m1.Rows);
                Console.WriteLine(m1.Columns);

                Console.WriteLine("----------------");

                Matrix m2 = new Matrix(2, 2);                             // Test properties (Size), Test method IsSquared
                Console.WriteLine(m.Size);
                Matrix m3 = new Matrix(1, 2);
                Console.WriteLine(m2.Size);
                if (m2.IsSquared)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");
                if (m3.IsSquared)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");

                Console.WriteLine("----------------");

                Matrix m4 = new Matrix(2, 2);                             // Test method IsEmpty
            if (m4.IsEmpty)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");

                Console.WriteLine("----------------");

                double[,] d1 = { { 1, 0 }, { 0, 1 } };                    // Test method IsUnity
            Matrix m5 = new Matrix(d1);
                if (m5.IsUnity)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");

                Console.WriteLine("----------------");

                double[,] d2 = { { 5, 1, 3 }, { 1, 6, 4 }, { 3, 4, 8 } }; // Test method IsSymmetric
            Matrix m6 = new Matrix(d2);
                if (m6.IsSymmetric)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");

                Console.WriteLine("----------------");
                
                double[,] d3 = { { 0, 1 }, { 1, 0 } };                    // Test Sum Matrix
            double[,] d4 = { { 1, 0 }, { 0, 1 } };
                Matrix m7 = new Matrix(d3);
                Matrix m8 = new Matrix(d4);
                Matrix m9 = m7 + m8;
                Console.WriteLine(m3.ToString());

                Console.WriteLine("----------------");

                double[,] d5 = { { 0, 1 }, { 1, 0 } };                    // Test Sum Matrix
                Matrix m10 = (Matrix)d5;
                Console.WriteLine(m10.ToString());

                Console.WriteLine("----------------");

                double[,] d6 = { { 5, 1 }, { 1, 6 } };                    // Test Trace Matrix
                Matrix m11 = new Matrix(d6);
                Console.WriteLine(m11.Trace());

                Console.WriteLine("----------------");                    // Test GetUnity and GetEmpty Matrix

                Console.WriteLine(Matrix.GetUnity(2, 2).ToString());
                Console.WriteLine(Matrix.GetEmpty(2, 2).ToString());

                Console.WriteLine("----------------");

                string str = "13362 2 3; 1 3 2; 2 4 3;";                  // Test Parse StringToMatrix
                Matrix m12 = Matrix.Parse(str);
                Console.WriteLine(m12.ToString());
        }
    }
    public class Matrix
    {
        private double[][] mas;
        private int size_first;
        private int size_second;
        public Matrix(int nRows, int nCols)
        {
            this.size_first = nRows;
            this.size_second = nCols;
            this.mas = new double[nRows][];
            for (int i = 0; i < nRows; i++)
            {
                this.mas[i] = new double[nCols];
            }
        }
        public Matrix(double[,] initData)
        {
            this.size_first = initData.GetUpperBound(0);
            this.size_second = initData.GetUpperBound(1);
            this.mas = new double[this.size_first + 1][];
            for (int i = 0; i < this.size_first + 1; i++)
                this.mas[i] = new double[this.size_second + 1];
            for (int i = 0; i < this.size_second + 1; i++)
            {
                for (int j = 0; j < this.size_second + 1; j++)
                {
                    this.mas[i][j] = initData[i, j];
                }
            }
        }
        public double this[int i, int j]
        {
            get => mas[i][j];
            set => mas[i][j] = value;
        }
        public int Rows { get { return this.mas.Length; } }
        public int Columns { get { return this.mas[0].Length; } }
        public int? Size
        {
            get
            {
                if (this.mas.Length == this.mas[0].Length)
                    return this.mas.Length;
                return null;
            }
        }
        public bool IsSquared
        {
            get
            {
                if (this.mas.Length == this.mas[0].Length)
                    return true;
                return false;
            }
        }
        public bool IsEmpty
        {
            get
            {
                foreach (var mas2 in this.mas)
                {
                    foreach (var e in mas2)
                    {
                        if (e != 0)
                            return false;
                    }
                }
                return true;
            }
        }
        public bool IsUnity
        {
            get
            {
                if (!IsSquared)
                    return false;
                for (int i = 0; i < this.mas.Length; i++)
                {
                    for (int j = 0; j < this.mas[0].Length; j++)
                    {
                        if (i == j && this.mas[i][j] != 1)
                            return false;
                        else if (i != j && this.mas[i][j] != 0)
                            return false;
                    }
                }
                return true;
            }
        }
        public bool IsSymmetric
        {
            get
            {
                if (!IsSquared)
                    return false;
                for (int i = 0; i < this.mas.Length; i++)
                {
                    for (int j = 0; j < this.mas[0].Length; j++)
                    {
                        if (i != j && this.mas[i][j] != this.mas[j][i])
                            return false;
                    }
                }
                return true;
            }
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix res_m = new Matrix(m1.Rows, m1.Columns);
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                return res_m;
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    res_m[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return res_m;
        }
        public static explicit operator Matrix(double[,] arr)
        {
            Matrix res_m = new Matrix(arr.GetUpperBound(0) + 1, arr.GetUpperBound(1) + 1);
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    res_m[i, j] = arr[i, j];
                }
            }
            return res_m;
        }
        public double Trace()
        {
            if (!IsSquared)
                return 0;
            double sum = 0;
            for (int i = 0; i < this.mas.Length; i++)
            {
                for (int j = 0; j < this.mas[0].Length; j++)
                {
                    if (i == j)
                    {
                        sum += this.mas[i][j];
                    }
                }
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < this.mas.Length; i++)
            {
                for (int j = 0; j < this.mas[0].Length; j++)
                {
                    s.Append(this.mas[i][j].ToString() + " ");
                }
                s.Remove(s.Length - 1, 1);
                s.Append("; ");
            }
            return s.ToString();
        }
        public static Matrix GetUnity(int size1, int size2)
        {
            Matrix res_m = new Matrix(size1, size2);
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    if (i == j)
                        res_m[i, j] = 1;
                    else
                        res_m[i, j] = 0;
                }
            }
            return res_m;
        }
        public static Matrix GetEmpty(int size1, int size2)
        {
            Matrix res_m = new Matrix(size1, size2);
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    res_m[i, j] = 0;
                }
            }
            return res_m;
        }
        public static Matrix Parse(string s)
        {
            string[] str = s.Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] str2 = str[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[] c = { ' ', ';' };
            string[] str_f = s.Split(c, StringSplitOptions.RemoveEmptyEntries);
            Matrix res_m = new Matrix(str.Length, str2.Length);
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str.Length != str[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length)
                        throw new FormatException();
                    res_m[i, j] = Convert.ToDouble(str_f[i * str2.Length + j]);
                }
            }
            return res_m;
        }
        public bool Compare_With_Double(double[,] d)
        {
            for (int i = 0; i < this.mas.Length; i++)
            {
                for (int j = 0; j < this.mas[0].Length; j++)
                {
                    if (this[i, j] != d[i,j])
                        return false;
                }
            }
            return true;
        }
    }
}