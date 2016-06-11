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

        //第一四分位数計算
        public static double calc_q1(double[] dataarray)
        {
            double result;

            //下位のデータ
            double[] lowerData = new double[dataarray.Length / 2];
            Array.Copy(dataarray, 0, lowerData, 0, dataarray.Length / 2);

            if (lowerData.Length >= 3)
            {
                if (lowerData.Length % 2 == 0)
                {
                    result = (lowerData[lowerData.Length / 2] + lowerData[(lowerData.Length / 2) + 1]) / 2;
                }
                else
                {
                    result = lowerData[(lowerData.Length / 2) + 1] / 2;
                }
            }
            else if(lowerData.Length == 2)
            {
                result = (lowerData[0] + lowerData[1]) / 2;
            }
            else if(lowerData.Length == 1)
            {
                result = lowerData[0];
            }
            else
            {
                result = 0;
            }

            return result;
            
        }
    }
}
