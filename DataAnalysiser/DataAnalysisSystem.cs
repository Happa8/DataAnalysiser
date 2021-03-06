﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysiser
{


    public static class DataAnalysisSystem
    {
        //平均値計算
        public static double calc_Ave(double[] dataarray)
        {
            double tmp = 0;
            double result;
            foreach(double d in dataarray)
            {
                tmp += d;
            }

            result = tmp / dataarray.Length;
            return result;
        }

        //中央値計算
        public static double calc_q2(double[] dataarray)
        {
            double result;
            if (dataarray.Length >= 3)
            {
                if (dataarray.Length % 2 == 0)
                {
                    result = (dataarray[dataarray.Length / 2] + dataarray[(dataarray.Length / 2) + 1]) / 2;

                }
                else
                {
                    int arraynum = (dataarray.Length / 2 + 1);
                    result = dataarray[arraynum];
                }
            }
            else if (dataarray.Length == 2)
            {
                result = (dataarray[0] + dataarray[1]) / 2;
            }
            else
            {
                result = dataarray[0];
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
                    result = lowerData[(lowerData.Length / 2) + 1];
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

        //第三四分位数計算
        public static double calc_q3(double[] dataarray)
        {
            double result;

            //上位のデータ
            double[] upperData = new double[dataarray.Length / 2];
            if (dataarray.Length % 2 == 0)
            {
                Array.Copy(dataarray, dataarray.Length / 2, upperData, 0, dataarray.Length / 2);
            }
            else
            {
                Array.Copy(dataarray, (dataarray.Length / 2) + 1, upperData, 0, dataarray.Length / 2);
            }

            if (upperData.Length >= 3)
            {
                if (upperData.Length % 2 == 0)
                {
                    result = (upperData[upperData.Length / 2] + upperData[(upperData.Length / 2) + 1]) / 2;
                }
                else
                {
                    result = upperData[(upperData.Length / 2) + 1];
                }
            }
            else if (upperData.Length == 2)
            {
                result = (upperData[0] + upperData[1]) / 2;
            }
            else if (upperData.Length == 1)
            {
                result = upperData[0];
            }
            else
            {
                result = 0;
            }

            return result;
        }
        
        //四分位範囲計算
        public static double calc_IQR(double[] dataarray)
        {
            return calc_q3(dataarray) - calc_q1(dataarray);
        }

        //四分位偏差計算
        public static double calc_QD(double[] dataarray)
        {
            return (calc_q3(dataarray) - calc_q1(dataarray)) / 2;
        }

        //分散計算
        public static double calc_S2(double[] dataarray)
        {
            double Ave = calc_Ave(dataarray);
            double tmp = 0;
            double result;

            foreach (double d in dataarray)
            {
                tmp += Math.Pow(d - Ave, 2);
            }

            result = tmp / dataarray.Length;
            return result;
            
        }

        //標準偏差計算
        public static double calc_S(double[] dataarray)
        {
            double S2 = calc_S2(dataarray);
            double result = Math.Sqrt(S2);

            return result;
        }
        
    }
}
