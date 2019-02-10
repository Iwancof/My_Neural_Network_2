using System;
using System.Collections.Generic;
using System.Text;

namespace My_Neural_Network_2
{
    public static class Math
    {
        public static double In_Product(double[] x,double[] y) {
            if (x.Length != y.Length) throw new Exception("ベクトルの長さが違っています。");
            double result = 0;
            for (int i = 0; i < x.Length; i++)
                result += x[i] * y[i];
            return result;
        }

        public static double[] Dimension_Down(double[,] Input,int n) {
            double[] Result = new double[Input.GetLength(1)];
            for(int i = 0;i < Result.Length; i++) 
                Result[i] = Input[n, i];
            return Result;
        }
    }
}
