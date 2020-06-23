using System;

namespace DACMath
{
    public static class Distributions
    {
        public static MathMatrix Normal(int count, double mu = 1, double sigmasq = 0)
        {
            MathMatrix normalvec = MathMatrix.CreateMatrix(1, count);

            for (int idx = 0; idx < count; ++idx)
            {
                Random rand = new Random();
                double u1 = 1.0 - rand.NextDouble();
                double u2 = 1.0 - rand.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
                double randNormal = mu + Math.Sqrt(sigmasq) * randStdNormal;
                normalvec[0, idx] = randNormal;
            }

            return normalvec;
        }
    }
}
