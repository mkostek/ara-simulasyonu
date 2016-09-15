/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: Mert
 * Tarih: 13.04.2015
 * Zaman: 17:46
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections.Generic;
using System.Linq;


namespace araç_simulation
{
	/// <summary>
	/// Description of Helper_.
	/// </summary>
 public static class Helper
    {
        public static double Variance(this IEnumerable<double> source)
        {
            double avg = source.Average();
            double d = source.Aggregate(0.0, (total, next) => total += Math.Pow(next - avg, 2));
            return d / (source.Count() - 1);
        }

        public static double Mean(this IEnumerable<double> source)
        {
            if (source.Count() < 1)
                return 0.0;

            double length = source.Count();
            double sum = source.Sum();
            return sum / length;
        }

        public static double NormalDist(double x, double mean, double standard_dev)
        {
            double fact = standard_dev * Math.Sqrt(2.0 * Math.PI);
            double expo = (x - mean) * (x - mean) / (2.0 * standard_dev * standard_dev);
            return Math.Exp(-expo) / fact;
        }

        public static double NORMDIST(double x, double mean, double standard_dev, bool cumulative)
        {
            const double parts = 50000.0; //large enough to make the trapzoids small enough

            double lowBound = 0.0;
            if (cumulative) //do integration: trapezoidal rule used here
            {
                double width = (x - lowBound) / (parts - 1.0);
                double integral = 0.0;
                for (int i = 1; i < parts - 1; i++)
                {
                    integral += 0.5 * width * (NormalDist(lowBound + width * i, mean, standard_dev) +
                        (NormalDist(lowBound + width * (i + 1), mean, standard_dev)));
                }
                return integral;
            }
            else //return function value
            {
                return NormalDist(x, mean, standard_dev);
            }
        }

        public static double SquareRoot(double source)
        {
            return Math.Sqrt(source);
        }
    }
}