﻿using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Polinom
{

    public class Polinomyal :
        IEquatable<Polinomyal>, ICloneable
    //,ICollection<Polinomyal>, IEnumerable<Polinomyal>;

    {
        /// <summary>
        /// Нулевой константный полином
        /// </summary>
        public static readonly Polinomyal ZERO;
        /// <summary>
        /// Статический конструктор, создающий нулевой константный
        /// полином
        /// </summary>
        static Polinomyal()
        {
            ZERO = new Polinomyal(0);
        }
        /// <summary>
        /// список коэффициентов многочлена
        /// </summary>
        protected List<double> _coefficients = new List<double>();
        /// <summary>
        /// Степень многочлена
        /// </summary>
        public int MaxPower
        {
            get { return _coefficients.Count - 1; }
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// создает многочлен 0-й степени со свободным членом, равным нулю
        /// </summary>
        public Polinomyal()
        {
            _coefficients = new List<double> { 0 };
        }
        /// <summary>Создает полином от строки данной
        /// </summary>
        public Polinomyal(string str)
        {
            _coefficients = Polinomyal.Parse(str)._coefficients;
        }
        /// <summary>
        /// Конструктор
        /// создает многочлен, используя список коэффициентов
        /// </summary>
        /// <param name="coefficients"></param>
        public Polinomyal(IList<double> coefficients)
        {
            int lastValuable = 0;
            for (int i = coefficients.Count - 1; i >= 0; i--)
            {
                if (coefficients[i] != 0)
                {
                    lastValuable = i;
                    break;
                }
            }
            _coefficients = coefficients.Take(lastValuable + 1).ToList();
        }

        /// <summary>
        /// Конструктор
        /// создает многочлен, используя коллекцию коэффициентов
        /// </summary>
        /// <param name="values"></param>
        public Polinomyal(IEnumerable<double> values) : this(values.ToList())
        {
            ;
        }
        /// <summary>
        /// Коэффициент многочлена при x^(index)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get { return _coefficients[index]; }
            set { _coefficients[index] = value; }
        }
        /// <summary>
        /// Конструктор
        /// создает многочлен 0-й степени с заданным свободным членом
        /// </summary>
        /// <param name="val"></param>
        public Polinomyal(double val)
        {
            _coefficients = new List<double> { val };
        }

        /// <summary>
        /// Вычисление значения многочлена в заданной точке x
        /// с помощью алгоритма схемы Горнера
        /// </summary>
        /// <param name="x">Точка, в которой нужно найти значение многочлена</param>
        /// <returns></returns>
        public double CalculateAt(double x)
        {
            double res = 0;
            for (int i = MaxPower; i >= 0; i--)
                res = res * x + _coefficients[i];
            return res;
        }
        /// <summary>
        /// Прибавление к текущему многочлену другого многочлена
        /// </summary>
        /// <param name="other">Второе слагаемое</param>
        /// <returns>Результат сложения двух многочленов</returns>
        public Polinomyal Add(Polinomyal other)
        {
            List<double> coefs = new List<double>();
            int i = 0;
            while (i <= other.MaxPower && i <= this.MaxPower)
            {
                coefs.Add(_coefficients[i] + other[i]);
                i++;
            }
            while (i <= this.MaxPower)
            {
                coefs.Add(_coefficients[i]);
                i++;
            }
            while (i <= other.MaxPower)
            {
                coefs.Add(other[i]);
                i++;
            }

            return new Polinomyal(coefs);
        }
        /// <summary>
        /// Вычитание из текущего многочлена другого многочлена
        /// </summary>
        /// <param name="other">Вычитаемое</param>
        /// <returns>Результат разности двух многочленов</returns>
        public Polinomyal Sub(Polinomyal other)
        {
            List<double> coefs = new List<double>();
            int i = 0;
            while (i <= other.MaxPower && i <= this.MaxPower)
            {
                coefs.Add(_coefficients[i] - other[i]);
                i++;
            }
            while (i <= this.MaxPower)
            {
                coefs.Add(_coefficients[i]);
                i++;
            }
            while (i <= other.MaxPower)
            {
                coefs.Add(-other[i]);
                i++;
            }

            return new Polinomyal(coefs);
        }
        /// <summary>
        /// Умножение текущего многочлена на другой многочлен
        /// </summary>
        /// <param name="other">Второй множитель в произведении</param>
        /// <returns>Результат произведения двух многочленов</returns>
        public Polinomyal Multiply(Polinomyal other)
        {
            double[] coefs = new double[this.MaxPower + other.MaxPower + 2];
            for (int i = 0; i <= this.MaxPower; i++)
            {
                for (int j = 0; j <= other.MaxPower; j++)
                {
                    coefs[i + j] += _coefficients[i] * other[j];
                }
            }
            return new Polinomyal(coefs);
        }
        /// <summary>
        /// Деление с остатком текущего многочлена на другой
        /// </summary>
        /// <param name="q">Делитель</param>
        /// <returns>Частное от деления одного многочлена на другой</returns>
        public virtual Polinomyal Divide(Polinomyal q)
        {
            int n = this.MaxPower;
            int m = q.MaxPower;
            if (n < m)
                return new Polinomyal(0);

            double[] numerator = this._coefficients.ToArray();
            double[] denominator = q._coefficients.ToArray();

            Array.Reverse(denominator);
            Array.Reverse(numerator);
            Stack<double> res = new();

            for (int i = 0; i <= n - m; i++)
            {
                double coef = numerator[i] / denominator[0];
                res.Push(coef);
                for (int j = 0; j <= m; j++)
                {
                    numerator[i + j] -= (denominator[j] * coef);
                }
            }

            return new Polinomyal(res);

        }
        /// <summary>
        /// Нахождения остатка от деления текущего многочлена на другой
        /// </summary> 
        /// <param name="q">Делитель</param>
        /// <returns>Остаток от деления одного многочлена на другой</returns>
        public Polinomyal Mod(Polinomyal q)
        {
            int n = this.MaxPower;
            int m = q.MaxPower;
            if (n < m)
                return new Polinomyal(this._coefficients);

            double[] numerator = this._coefficients.ToArray();
            double[] denominator = q._coefficients.ToArray();
            Array.Reverse(denominator);
            Array.Reverse(numerator);

            for (int i = 0; i <= n - m; i++)
            {
                double coef = numerator[i] / denominator[0];
                for (int j = 0; j <= m; j++)
                {
                    numerator[i + j] -= (denominator[j] * coef);
                }
            }
            Array.Reverse(numerator);
            return (new Polinomyal(numerator));
        }



        /// <summary>
        /// Возведение многочлена в степень с помощью алгоритма быстрой экспоненциации
        /// </summary>
        /// <param name="pow">Степень, в которую нужно возвести многочлен</param>
        /// <returns>Многочлен в степени pow</returns>
        public Polinomyal Pow(int pow)
        {
            Polinomyal res = (Polinomyal)this.Clone();
            res = PowRange(res, pow);
            return res;
        }
        /// <summary>
        /// Вспомогательная функция для логарифмического возведения
        /// полинома в степень
        /// </summary>
        private Polinomyal PowRange(Polinomyal temp, int pow)
        {
            if (pow == 0)
                return new Polinomyal(1);
            if (pow == 1)
                return temp;
            if (pow == 2)
                return temp * temp;

            if (pow % 2 == 0)
                return PowRange(temp, pow / 2) * PowRange(temp, pow / 2);
            else
                return PowRange(temp, pow / 2) * PowRange(temp, pow - pow / 2);

        }
        /// <summary>
        /// Сложение многочлена и числа
        /// </summary>
        /// <param name="other">Второе слагаемое</param>
        /// <returns>Результат сложения</returns>
        public Polinomyal Add(double other)
        {
            Polinomyal res = (Polinomyal)this.Clone();
            res[0] += other;
            return res;
        }
        /// <summary>
        /// Вычитание числа из многочлена
        /// </summary>
        /// <param name="other">Вычитаеоме</param>
        /// <returns>Результат вычитания</returns>
        public Polinomyal Sub(double other)
        {
            Polinomyal res = (Polinomyal)this.Clone();
            res[0] -= other;
            return res;
        }
        /// <summary>
        /// Умножение многочлена на число
        /// </summary>
        /// <param name="other">Множитель</param>
        /// <returns>Результат умножения</returns>
        public Polinomyal Multiply(double other)
        {
            Polinomyal res = (Polinomyal)this.Clone();
            for (int i = 0; i <= MaxPower; i++)
                res[i] *= other;
            return res;
        }
        /// <summary>
        /// Деление многочлена на число
        /// </summary>
        /// <param name="other">Делитель</param>
        /// <returns>Результат деления</returns>
        public Polinomyal Divide(double other)
        {
            Polinomyal res = (Polinomyal)this.Clone();
            for (int i = 0; i <= MaxPower; i++)
                res[i] /= other;
            return res;
        }
        /// <summary>
        /// Перегрузка оператора + для класса Polynomyal
        /// </summary>
        /// <param name="left">Первый многочлен</param>
        /// <param name="right">Второй многочлен</param>
        /// <returns>Результат сложения</returns>
        public static Polinomyal operator +(Polinomyal left, Polinomyal right)
        {
            return left.Add(right);
        }
        /// <summary>
        /// Перегрузка оператора + для многочлена и числа
        /// </summary>
        /// <param name="left">Многочлен</param>
        /// <param name="right">Число</param>
        /// <returns>Результат сложения</returns>
        public static Polinomyal operator +(Polinomyal left, double right)
        {
            return left.Add(right);
        }
        /// <summary>
        /// Перегрузка оператора - для класса Polynomyal
        /// </summary>
        /// <param name="left">Первый многочлен</param>
        /// <param name="right">Второй многочлен</param>
        /// <returns>Результат вычитания</returns>
        public static Polinomyal operator -(Polinomyal left, Polinomyal right)
        {
            return left.Sub(right);
        }
        /// <summary>
        /// Перегрузка оператора - для многочлена и числа
        /// </summary>
        /// <param name="left">Многочлен</param>
        /// <param name="right">Число</param>
        /// <returns>Результат вычитания</returns>
        public static Polinomyal operator -(Polinomyal left, double right)
        {
            return left.Sub(right);
        }
        /// <summary>
        /// Перегрузка оператора * для класса Polynomyal
        /// </summary>
        /// <param name="left">Первый многочлен</param>
        /// <param name="right">Второй многочлен</param>
        /// <returns>Результат умножения</returns>
        public static Polinomyal operator *(Polinomyal left, Polinomyal right)
        {
            return left.Multiply(right);
        }
        /// <summary>
        /// Перегрузка оператора * для многочлена и числа
        /// </summary>
        /// <param name="left">Многочлен</param>
        /// <param name="right">Число</param>
        /// <returns>Результат умножения</returns>
        public static Polinomyal operator *(Polinomyal left, double right)
        {
            return left.Multiply(right);
        }
        /// <summary>
        /// Перегрузка оператора / для класса Polynomyal
        /// </summary>
        /// <param name="left">Первый многочлен</param>
        /// <param name="right">Второй многочлен</param>
        /// <returns>Результат деления</returns>
        public static Polinomyal operator /(Polinomyal left, Polinomyal right)
        {
            return left.Divide(right);
        }
        /// <summary>
        /// Перегрузка оператора / для многочлена и числа
        /// </summary>
        /// <param name="left">Многочлен</param>
        /// <param name="right">Число</param>
        /// <returns>Результат деления</returns>
        public static Polinomyal operator /(Polinomyal left, double right)
        {
            return left.Divide(right);
        }

        /// <summary>
        /// Оператор взятия остатка от деления
        /// </summary>
        /// <param name="left">Первый многочлен</param>
        /// <param name="right">Второй многочлен</param>
        /// <returns>true если многочлены равны, false в остальных случаях</returns>
        /// <summary>
        /// Перегрузка оператора / для многочлена и числа
        /// </summary>
        /// <param name="left">Многочлен</param>
        /// <param name="right">Число</param>
        /// <returns>Результат деления</returns>
        public static Polinomyal operator %(Polinomyal left, Polinomyal right)
        {
            return left.Mod(right);
        }
        public static bool operator ==(Polinomyal left, Polinomyal right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }
        /// <summary>
        /// Оператор проверки двух многочленов на неравенство
        /// </summary>
        /// <param name="left">Первый многочлен</param>
        /// <param name="right">Второй многочлен</param>
        /// <returns>false если многочлены равны, true в остальных случаях</returns>
        public static bool operator !=(Polinomyal left, Polinomyal right)
        {
            return !(left == right);
        }
        /// <summary>
        /// Переопределение метода ToString для класса Polinomyal
        /// </summary>
        /// <returns>Строковое представление многочлена</returns>
        public override string ToString()
        {
            string result = "";

            for (int i = _coefficients.Count - 1; i >= 0; i--)
            {

                if (_coefficients[i] == 0)
                    continue;


                string sgn = _coefficients[i] > 0 ? "+" : "-";
                if (result == "" && sgn == "+")
                    sgn = "";

                string val = Math.Abs(_coefficients[i]).ToString();
                if (Math.Abs(_coefficients[i]) == 1 && i != 0)
                {
                    val = "";
                }
                else
                {
                    val = Math.Abs(_coefficients[i]).ToString();
                }

                string pow;
                if (i == 1)
                {
                    pow = "";
                }
                else
                {
                    pow = "^" + i.ToString();
                }
                if (i == 0)
                {
                    pow = "";
                    result += $"{sgn} {val}{pow} ";
                    return result;
                }

                result += $"{sgn} {val}x{pow} ";
            }

            return result;
        }
        /// <summary>
        /// Переопределение метода Equals для класса Polinomyal
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
                return true;
            if (ReferenceEquals(obj, null))
            {
                return ReferenceEquals(this, null);
            }
            if (obj is not Polinomyal)
                return false;

            Polinomyal polinomyal = (Polinomyal)obj;

            if (polinomyal.MaxPower != this.MaxPower)
                return false;

            for (int i = 0; i <= MaxPower; i++)
            {
                if (this[i] != polinomyal[i])
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Проверяет, является ли текущий полином нулевым
        /// </summary>
        /// <returns>
        /// True: является,
        /// False: не является
        /// </returns>
        public bool IsZero()
        {
            return this.Equals(ZERO);
        }
        /// <summary>
        /// Переопределение метода Equals для класса Polinomyal
        /// </summary>
        /// <param name="other">Многочлен для сравнения</param>
        /// <returns></returns>
        public bool Equals(Polinomyal? other)
        {
            if (ReferenceEquals(other, this))
                return true;
            if (ReferenceEquals(other, null))
            {
                return ReferenceEquals(this, null);
            }

            if (other.MaxPower != this.MaxPower)
                return false;

            for (int i = 0; i <= MaxPower; i++)
            {
                if (this[i] != other[i])
                    return false;
            }

            return true;

        }
        /// <summary>
        /// Метод для клонирования многочлена
        /// </summary>
        /// <returns>Клон текущего многочлена</returns>
        public object Clone()
        {
            return new Polinomyal(_coefficients);
        }
        //5x^2 + 6x - 7 + x^3
        /// <summary>
        /// Парсинг многочлена из строки
        /// </summary>
        /// <param name="s">Строка, содержащая многочлен</param>
        /// <returns>Экземпляр класса Polinomyal, преобразованный из строки</returns>
        public static Polinomyal Parse(string s)
        {
            string[] values = GetBuffered(s);
            Dictionary<int, double> powsCoefs = new();
            powsCoefs.Add(ParsePart(values[0]).Item1,
                ParsePart(values[0]).Item2);
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i - 1] == "-")
                {
                    powsCoefs.Add(ParsePart(values[i]).Item1,
                        -ParsePart(values[i]).Item2);

                }
                else if (values[i - 1] == "+")
                {
                    powsCoefs.Add(ParsePart(values[i]).Item1,
                        ParsePart(values[i]).Item2);
                }
            }

            double[] value = new double[powsCoefs.Keys.Max() + 1];
            for (int i = 0; i < value.Length; i++)
            {
                powsCoefs.TryGetValue(i, out value[i]);
            }

            return new Polinomyal(value);

        }

        //5x^3, 5x^3, x^3, x^3, x, x, 6, 6, 5x
        protected static (int, double) ParsePart(string part)
        {
            int pow;
            double coef;
            if (!part.Contains('x'))
            {
                return (0, Convert.ToDouble(part));
            }

            string[] buf = part.Split('x');
            if (!part.Contains('^'))
            {
                pow = 1;
                if (buf[0] == "")
                {
                    coef = 1;
                }
                else if (buf[0] == "-")
                {
                    coef = 1;
                }
                else
                {
                    coef = Convert.ToDouble(buf[0]);
                }
            }
            else
            {
                if (buf[0] == "")
                {
                    coef = 1;
                    pow = Convert.ToInt32(buf[1].Substring(1));
                }
                else if (buf[0] == "-")
                {
                    coef = -1;
                    pow = Convert.ToInt32(buf[1].Substring(1));
                }
                else
                {
                    coef = Convert.ToDouble(buf[0]);
                    pow = Convert.ToInt32(buf[1].Substring(1));
                }
            }

            return (pow, coef);
        }

        protected static string[] GetBuffered(string s)
        {
            s = s.Trim().ToLower();
            StringBuilder sb = new();

            int lastSplit = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int j = i;
                while (c == ' ')
                {
                    j++;
                    c = s[j];
                }
                if (j != i)
                {
                    sb.Append(s.Substring(lastSplit, i - lastSplit) + "@");
                    lastSplit = j;
                    i = j - 1;

                    continue;
                }
            }
            sb.Append(s.Substring(lastSplit, s.Length - lastSplit));

            for (int i = 0; i < sb.Length; i++)
            {
                char c = sb[i];
                if ((c == '-' || c == '+'))
                {
                    if (sb[i - 1] != '@')
                    {
                        sb.Insert(i, '@');
                        i++;
                    }
                    if (sb[i + 1] != '@')
                    {
                        sb.Insert(i + 1, '@');
                    }
                }
            }
            return sb.ToString().Split('@');
        }


    }

    public class RootedPolinomyal : Polinomyal
    {
        const double PRECISION = 0.001;
        static readonly int NUMBERS_AFTER_ZERO = (int)-Math.Log10(PRECISION);
        const int startRootSegment = -10000;
        const int endRootSegment = 10000;
        public RootedPolinomyal(string str) : base(str)
        {

        }
        /// <summary>
        /// Конструктор по умолчанию
        /// создает многочлен 0-й степени со свободным членом, равным нулю
        /// </summary>
        public RootedPolinomyal() : base()
        {

        }
        /// <summary>
        /// Конструктор
        /// создает многочлен, используя список коэффициентов
        /// </summary>
        /// <param name="coefficients"></param>
        public RootedPolinomyal(IList<double> coefficients) : base(coefficients)
        {

        }

        /// <summary>
        /// Конструктор
        /// создает многочлен, используя коллекцию коэффициентов
        /// </summary>
        /// <param name="values"></param>
        public RootedPolinomyal(IEnumerable<double> values) : base(values.ToList())
        {

        }

        public RootedPolinomyal(double num) : base(num) { }
        /// <summary>
        /// Деление с остатком текущего многочлена на другой 
        /// с учетом погрешности
        /// </summary>
        /// <param name="q">Делитель</param>
        /// <returns>Частное от деления одного многочлена на другой</returns>
        public override RootedPolinomyal Divide(Polinomyal q)
        {
            int n = this.MaxPower;
            int m = q.MaxPower;
            if (n < m)
                return new RootedPolinomyal(0);

            double[] numerator = this._coefficients.ToArray();
            int rev = q.MaxPower;
            Array.Reverse(numerator);
            Stack<double> res = new();

            for (int i = 0; i <= n - m; i++)
            {
                if (Math.Abs(numerator[i]) < PRECISION)
                    numerator[i] = 0;
                double coef = numerator[i] / q[rev - 0];
                res.Push(coef);
                for (int j = 0; j <= m; j++)
                {
                    numerator[i + j] -= (q[rev - j] * coef);
                }
            }

            return new RootedPolinomyal(res);
        }
        /// <summary>
        /// Вычисление корней текущего многочлена
        /// </summary>
        /// <returns>Массив, содержащий корни многочлена</returns>
        public double[] GetRoots()
        {
            List<double> res = new();
            Polinomyal temp = (Polinomyal)this.Clone();
            while (!temp.IsZero())
            {
                double root = FindRoot(temp);
                if (root == double.MinValue || double.IsNaN(root))
                    break;
                res.Add(root);
                temp /= new Polinomyal(new double[] { -root, 1 });
            }
            return res.ToArray();
        }
        /// <summary>
        /// Находит один произвольный корень данного полинома
        /// </summary>
        /// <param name="p">Данный полином</param>
        /// <returns>Корень данного полинома</returns>
        private static double FindRoot(Polinomyal p)
        {
            return Math.Round(
                ApproximateRoot(p.CalculateAt, 10, PRECISION)
                , NUMBERS_AFTER_ZERO);
        }
        /// <summary>
        /// Находит приблизительный корень данной функции с необходимой точностью
        /// с помощью метода Ньютона
        /// </summary>
        /// <param name="function">Данная функция</param>
        /// <param name="initialGuess">Изначальное предположение</param>
        /// <param name="tolerance">Точность</param>
        /// <returns>Приблизительный корень данной функции с необходимой точностью
        /// с помощью метода Ньютона, если его удалось найти за 100000 циклов,
        /// иначе double.MinValue</returns>
        private static double ApproximateRoot(Func<double, double> function
            , double initialGuess, double tolerance)
        {
            double x0 = initialGuess;
            double x1 = x0 - function(x0) / Derivative(function, x0);
            int cycles = 100000;
            while (Math.Abs(x1 - x0) > tolerance)
            {
                cycles--;
                x0 = x1;
                x1 = x0 - function(x0) / Derivative(function, x0);
                if (cycles == 0)
                    return double.MinValue;
            }

            return x1;
        }
        /// <summary>
        /// Находит приближенное значение производной функции в данной точке
        /// </summary>
        /// <param name="function">Функция</param>
        /// <param name="x">Данная точка</param>
        /// <returns>Приближенное значение производной функции в данной точке</returns>
        private static double Derivative(Func<double, double> function, double x)
        {
            double h = 1e-10; // small number for calculating the derivative
            return (function(x + h) - function(x)) / h;
        }
        /// <summary>
        /// Находит точки экстремума данного полинома
        /// на отрезке [-10000; 10000]
        /// </summary>
        /// <returns>Массив точек экстремума данного полинома
        /// на отрезке [-10000; 10000]</returns>
        public double[] FindExtremePoint()
        {
            List<double> values = new List<double>();
            for (double i = startRootSegment; i < endRootSegment; i += 0.001)
            {
                if (Math.Abs(Derivative(this.CalculateAt, i)) < PRECISION)
                {
                    values.Add(i);
                    i += 1;
                }
            }

            return values.ToArray();
        }
        /// <summary>
        /// Возвращает значения полинома в точках экстремума
        /// </summary>
        /// <returns>Значения полинома в точках экстремума</returns>
        public double[] ExtremeValue()
        {
            List<double> res = new();
            foreach (var exP in FindExtremePoint())
            {
                res.Add(CalculateAt(exP));
            }
            return res.ToArray();
        }
        /// <summary>
        /// Воссоздает полином из списка его корней
        /// </summary>
        /// <param name="roots">Список корней</param>
        /// <returns>Полином, корни которого это только корни из данного списка</returns>
        public static Polinomyal ConstructFromRoots(IList<double> roots)
        {
            Polinomyal polinomyal = new Polinomyal(1);
            foreach (var root in roots)
            {
                polinomyal *= new Polinomyal(new List<double> { -root, 1 });
            }
            return polinomyal;
        }
        /// <summary>
        /// Строит новый RootedPolinomyal по данной строке
        /// </summary>
        /// <param name="s">Обрабатываемая строка</param>
        /// <returns>Новый RootedPolinomyal</returns>
        public static new RootedPolinomyal Parse(string s)
        {
            string[] values = GetBuffered(s);
            Dictionary<int, double> powsCoefs = new();
            powsCoefs.Add(ParsePart(values[0]).Item1,
                ParsePart(values[0]).Item2);
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i - 1] == "-")
                {
                    powsCoefs.Add(ParsePart(values[i]).Item1,
                        -ParsePart(values[i]).Item2);

                }
                else if (values[i - 1] == "+")
                {
                    powsCoefs.Add(ParsePart(values[i]).Item1,
                        ParsePart(values[i]).Item2);
                }
            }

            double[] value = new double[powsCoefs.Keys.Max() + 1];
            for (int i = 0; i < value.Length; i++)
            {
                powsCoefs.TryGetValue(i, out value[i]);
            }

            return new RootedPolinomyal(value);

        }
    }
}