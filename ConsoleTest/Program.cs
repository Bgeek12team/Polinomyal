﻿using Polinom;
namespace P
{
    class p
    {
        static void Main()
        {
            string test = "4x + 2x^3",
                test2 = "5 + 4x + 3x^2 + 2x^3";
            Polinomyal pp = Polinomyal.Parse(test);
            Polinomyal polinomyal = Polinomyal.Parse(test2);

            Console.WriteLine(pp.ToString());
            Console.WriteLine(polinomyal.ToString());
            Console.WriteLine(pp % polinomyal);

            IList<double> testRoots = new List<double> { 1, 1 };
            Polinomyal poli = RootedPolinomyal.ConstructFromRoots(testRoots);
            Console.WriteLine(poli);

            string test3 = "3x^2 - 7x";
            string testRoot = "x - 2,333";
            RootedPolinomyal rootedPolinomyal = new(test3);
            RootedPolinomyal test36 = new(testRoot);
            Console.WriteLine(rootedPolinomyal / test36);
        }
    }
}