namespace _02.Fraction_Calculator
{
    using System;
    using System.Numerics;

    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentNullException("value", "Denominator cannot be zero!");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            BigInteger resultNumerator = ((BigInteger)fraction1.Numerator * fraction2.Denominator) +
                                         ((BigInteger)fraction1.Denominator * fraction2.Numerator);

            BigInteger resultDenominator = (BigInteger)fraction1.Denominator * fraction2.Denominator;

            BigInteger gcd = GetGreatestCommnonDivisor(resultNumerator, resultDenominator);

            if (gcd > 1)
            {
                resultNumerator /= gcd;
                resultDenominator /= gcd;
            }

            if (resultNumerator < long.MinValue || long.MaxValue < resultNumerator)
            {
                throw new ArithmeticException("Numerator of resulting fraction is either too large or too small.");
            }

            if (resultDenominator > long.MaxValue)
            {
                throw new ArithmeticException("Denominator of resulting fraction is too large.");
            }

            return new Fraction((long)resultNumerator, (long)resultDenominator);
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = fraction1 + new Fraction(fraction2.Numerator * -1, fraction2.Denominator);
            return result;
        }

        private static BigInteger GetGreatestCommnonDivisor(BigInteger numerator, BigInteger denominator)
        {
            while (denominator != 0)
            {
                BigInteger tmp = denominator;
                denominator = numerator % denominator;
                numerator = tmp;
            }

            return numerator;
        }

        public override string ToString()
        {
            decimal numerator = this.Numerator;
            decimal denominator = this.Denominator;

            return (numerator / denominator).ToString();
        }
    }
}