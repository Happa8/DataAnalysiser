using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysiser
{


    public static class DataAnalysisSystem
    {

        //中央値計算
        public static double calc_q2(double[] dataarray)
        {
            double result;
            if (dataarray.Length % 2 == 0)
            {
                result = (dataarray[dataarray.Length / 2] + dataarray[(dataarray.Length / 2) - 1]) / 2;

            }
            else
            {
                int arraynum = (dataarray.Length / 2);
                result = dataarray[arraynum];
            }
            return result;
        }
    }
}
