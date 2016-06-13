using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysiser
{
    public static class BoxplotSystem
    {
        public static double[] setScale(double[] dataarray)
        {
            double minValue = dataarray[0];
            double maxValue = dataarray[dataarray.Length - 1];
            int maxValueI = (int)maxValue;
            int minValueI = (int)minValue;
            int maxDigits = maxValueI.ToString().Length;
            double[] result = new double[2];
            double maxScale = 0;
            double minScale = 0;
            if (maxValue >= 0 && minValue >= 0)
            {
                maxScale = (Math.Truncate(maxValue / Math.Pow(10, maxDigits - 1)) % 10 + 1) * Math.Pow(10, maxDigits - 1);
                minScale = 0;
            }
            else if (maxValue >= 0 && minValue < 0 && maxValue >= minValue)
            {
                maxScale = (Math.Truncate(maxValue / Math.Pow(10, maxDigits - 1)) % 10 + 1) * Math.Pow(10, maxDigits - 1);
                minScale = -1 * maxScale;
            }
            else if(maxValue >= 0 && minValue < 0 && maxValue < minValue)
            {
                int minDigits = (-1 * minValueI).ToString().Length;
                minScale = -1 * (Math.Truncate((-1 * minValue) / Math.Pow(10, minDigits - 1)) % 10 - 1) * Math.Pow(10, minDigits - 1);
                maxScale = -1 * minValue;
            }
            else if(maxValue < 0 && minValue < 0)
            {
                maxScale = 0;
                int minDigits = (-1 * minValueI).ToString().Length;
                minScale = -1 * (Math.Truncate((-1 * minValue) / Math.Pow(10, minDigits - 1)) % 10 - 1) * Math.Pow(10, minDigits - 1);
            }

            result[0] = minScale;
            result[1] = maxScale;
            return result;
        }
    }
}
