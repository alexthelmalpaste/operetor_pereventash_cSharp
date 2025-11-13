using System;
using System.Text;

namespace OperatorOverloadingDemo
{
    // Завдання 1: Співробітник
    class Spivrobitnyk
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Spivrobitnyk(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public static Spivrobitnyk operator +(Spivrobitnyk s, decimal amount) => new Spivrobitnyk(s.Name, s.Salary + amount);
        public static Spivrobitnyk operator -(Spivrobitnyk s, decimal amount) => new Spivrobitnyk(s.Name, s.Salary - amount);
        public static bool operator ==(Spivrobitnyk a, Spivrobitnyk b) => a?.Salary == b?.Salary;
        public static bool operator !=(Spivrobitnyk a, Spivrobitnyk b) => !(a == b);
        public static bool operator <(Spivrobitnyk a, Spivrobitnyk b) => a.Salary < b.Salary;
        public static bool operator >(Spivrobitnyk a, Spivrobitnyk b) => a.Salary > b.Salary;

        public override bool Equals(object obj) => obj is Spivrobitnyk s && Salary == s.Salary;
        public override int GetHashCode() => Salary.GetHashCode();
    }

    // Завдання 2: Місто
    class Misto
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public Misto(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public static Misto operator +(Misto m, int amount) => new Misto(m.Name, m.Population + amount);
        public static Misto operator -(Misto m, int amount) => new Misto(m.Name, m.Population - amount);
        public static bool operator ==(Misto a, Misto b) => a?.Population == b?.Population;
        public static bool operator !=(Misto a, Misto b) => !(a == b);
        public static bool operator <(Misto a, Misto b) => a.Population < b.Population;
        public static bool operator >(Misto a, Misto b) => a.Population > b.Population;

        public override bool Equals(object obj) => obj is Misto m && Population == m.Population;
        public override int GetHashCode() => Population.GetHashCode();
    }

    // Завдання 3: Кредитна картка
    class KreditnaKartka
    {
        public string Owner { get; set; }
        public string CVC { get; set; }
        public decimal Balance { get; set; }

        public KreditnaKartka(string owner, string cvc, decimal balance)
        {
            Owner = owner;
            CVC = cvc;
            Balance = balance;
        }

        public static KreditnaKartka operator +(KreditnaKartka k, decimal amount) => new KreditnaKartka(k.Owner, k.CVC, k.Balance + amount);
        public static KreditnaKartka operator -(KreditnaKartka k, decimal amount) => new KreditnaKartka(k.Owner, k.CVC, k.Balance - amount);
        public static bool operator ==(KreditnaKartka a, KreditnaKartka b) => a?.CVC == b?.CVC;
        public static bool operator !=(KreditnaKartka a, KreditnaKartka b) => !(a == b);
        public static bool operator <(KreditnaKartka a, KreditnaKartka b) => a.Balance < b.Balance;
        public static bool operator >(KreditnaKartka a, KreditnaKartka b) => a.Balance > b.Balance;

        public override bool Equals(object obj) => obj is KreditnaKartka k && CVC == k.CVC;
        public override int GetHashCode() => CVC.GetHashCode();
    }

    // Завдання 4: Матриця
    class Matrytsia
    {
        private double[,] data;
        public int Rows => data.GetLength(0);
        public int Cols => data.GetLength(1);

        public Matrytsia(int rows, int cols)
        {
            data = new double[rows, cols];
        }

        public double this[int i, int j]
        {
            get => data[i, j];
            set => data[i, j] = value;
        }

        public static Matrytsia operator +(Matrytsia a, Matrytsia b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new InvalidOperationException("Розміри не збігаються");
            var result = new Matrytsia(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = a[i, j] + b[i, j];
            return result;
        }

        public static Matrytsia operator -(Matrytsia a, Matrytsia b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new InvalidOperationException("Розміри не збігаються");
            var result = new Matrytsia(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = a[i, j] - b[i, j];
            return result;
        }

        public static Matrytsia operator *(Matrytsia a, double scalar)
        {
            var result = new Matrytsia(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = a[i, j] * scalar;
            return result;
        }

        public static Matrytsia operator *(Matrytsia a, Matrytsia b)
        {
            if (a.Cols != b.Rows)
                throw new InvalidOperationException("Несумісні розміри для множення");
            var result = new Matrytsia(a.Rows, b.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Cols; j++)
                    for (int k = 0; k < a.Cols; k++)
                        result[i, j] += a[i, k] * b[k, j];
            return result;
        }

        public static bool operator ==(Matrytsia a, Matrytsia b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            if (a.Rows != b.Rows || a.Cols != b.Cols) return false;
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    if (a[i, j] != b[i, j]) return false;
            return true;
        }

        public static bool operator !=(Matrytsia a, Matrytsia b) => !(a == b);
        public override bool Equals(object obj) => obj is Matrytsia m && this == m;
        public override int GetHashCode() => data.GetHashCode();

        // Human-friendly string representation for Console.WriteLine
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                sb.Append("[");
                for (int j = 0; j < Cols; j++)
                {
                    sb.Append(this[i, j]);
                    if (j < Cols - 1) sb.Append(", ");
                }
                sb.Append("]");
                if (i < Rows - 1) sb.AppendLine();
            }
            return sb.ToString();
        }
    }

    // Тестування
    class Program
    {
        static void Main()
        {
            var s1 = new Spivrobitnyk("Іван", 10000);
            var s2 = s1 + 2000;
            Console.WriteLine($"Зарплата після підвищення: {s2.Salary}");

            var m1 = new Misto("Одеса", 1000000);
            var m2 = m1 - 50000;
            Console.WriteLine($"Нове населення: {m2.Population}");

            var k1 = new KreditnaKartka("Саша", "123", 5000);
            var k2 = k1 + 1500;
            Console.WriteLine($"Баланс картки: {k2.Balance}");

            var mat1 = new Matrytsia(2, 2);
            var mat2 = new Matrytsia(2, 2);
            mat1[0, 0] = 1; mat1[0, 1] = 2;
            mat1[1, 0] = 3; mat1[1, 1] = 4;
            mat2[0, 0] = 5; mat2[0, 1] = 6;
            mat2[1, 0] = 7; mat2[1, 1] = 8;

            var matSum = mat1 + mat2;
            // Fixed: properly close interpolated expression and provide textual representation of the matrix
            Console.WriteLine($"Сума матриць:{Environment.NewLine}{matSum}");
        }
    }
}