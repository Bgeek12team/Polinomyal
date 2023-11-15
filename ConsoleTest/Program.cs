using Polinom;
namespace P
{
    class p
    {
        static void Main()
        {
            /*string test = "4x + 2x^3",
                test2 = "5 + 4x + 3x^2 + 2x^3";
            Polinomyal pp = Polinomyal.Parse(test);
            Polinomyal polinomyal = Polinomyal.Parse(test2);

            Console.WriteLine(pp.ToString());
            Console.WriteLine(polinomyal.ToString());
            Console.WriteLine(pp % polinomyal);*/

            string testRoots = "4x^4 + 3x^2 - 3";
            RootedPolinomyal poli = new RootedPolinomyal(testRoots);
            double[] values = poli.FindExtremePoint();
            foreach(double el in values)
            {
                Console.WriteLine(el);
            }
            /*
            string test3 = "x^2 + 5x + 6";
            string testRoot = "x - 2,333";
            RootedPolinomyal rootedPolinomyal = new(test3);
            RootedPolinomyal test36 = new(testRoot);
            Console.WriteLine("aojfslasdjf;lk");
            Console.WriteLine(rootedPolinomyal);

            foreach( var root in rootedPolinomyal.GetRoots())
            {
                Console.WriteLine(root);
            }*/
        }
    }
}