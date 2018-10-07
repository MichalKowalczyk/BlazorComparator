using System;

namespace Blazor
{
    public class Complex
    {
        private double X;
        private double Y;

        public Complex(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double getX()
        {
            return X;
        }
        public double getY()
        {
            return Y;
        }
        public double modul2()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
        public Complex Add(Complex z)
        {
            Complex wynik = new Complex(X + z.X, Y + z.Y);
            return wynik;
        }
        public Complex kwadrat()
        {
            return new Complex(Math.Pow(X, 2) - (Math.Pow(Y, 2)), 2 * X * Y);
        }
    }
}


