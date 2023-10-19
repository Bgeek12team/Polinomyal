using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polinom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom.Tests
{
    [TestClass()]
    public class PolinomyalTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4 });
            Polinomyal polB = new Polinomyal(new List<double> { 1, 2, 3 });
            Polinomyal expected = new Polinomyal(new List<double> { 3, 5, 7 });

            Polinomyal actual = polA.Add(polB);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void AaddTest_ZeroCof()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(new List<double> { 0, 0, 0, 0 });
            Polinomyal expected = new Polinomyal(new List<double> { 2, 3, 4, 0 });

            Polinomyal actual = polA.Add(polB);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void AddTest_NoCof()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(new List<double> { 1, 2, 3 });
            Polinomyal expected = new Polinomyal(new List<double> { 3, 5, 7, 0 });

            Polinomyal actual = polA.Add(polB);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyTest_zeroAndNoCof()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(new List<double> { 1, 0, 3 });
            Polinomyal expected = new Polinomyal(new List<double> { 2, 3, 10, 9, 12});

            Polinomyal actual = polA.Multiply(polB);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MultiplyTest_EmptyPol()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(0);
            Polinomyal expected = Polinomyal.ZERO;

            Polinomyal actual = polA.Multiply(polB);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MultiplyTest()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(new List<double> { 1, 1, 1, 1 });
            Polinomyal expected = new Polinomyal(new List<double> { 2, 5, 9, 9, 7, 4 });

            Polinomyal actual = polA.Multiply(polB);

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void SubTest()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(new List<double> { 1, 1, 1, 1 });
            Polinomyal expected = new Polinomyal(new List<double> { 1, 2, 3, -1 });

            Polinomyal actual = polA.Sub(polB);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SubTest_Empty()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(new List<double> { });
            Polinomyal expected = new Polinomyal(new List<double> { 2, 3, 4, 0 });

            Polinomyal actual = polA.Sub(polB);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideTest_Empty()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 3, 4, 0 });
            Polinomyal polB = new Polinomyal(1);
            Polinomyal expected = new Polinomyal(new List<double> { 2, 3, 4, 0 });

            Polinomyal result = polA.Divide(polB);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DivideTest_zeroCof()
        {
            Polinomyal polA = new Polinomyal(new List<double> { 2, 0, 4, 0 });
            Polinomyal polB = new Polinomyal(new List<double> { 2, 3, 4, 5 });
            Polinomyal expected = new Polinomyal(new List<double> { 0 });

            Polinomyal result = polA.Divide(polB);

            Assert.AreEqual(expected, result);
        }

    }
}