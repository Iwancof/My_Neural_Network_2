using System;
using static System.Console;

namespace My_Neural_Network_2
{
    class Program
    {
        static void Main(string[] args) {
            Neural n = new Neural();
            //n.Update_Weigth(new double[] { 1, 1, 0 }, new double[] { 1, 0, 0 }, 0.1);

            double[][] input = new double[][] {
                new double[]{0,0,0},
                new double[]{0,1,0},
                new double[]{1,0,0},
                new double[]{1,1,0},
            };

            double[][] answer = new double[][] {
                new double[]{0,0},
                new double[]{0,1},
                new double[]{0,1},
                new double[]{1,0},
            };


            n.Train(input,answer,0.1,100000);

            double[] odata = n.Calc(input[1]);
            foreach (double x in odata)
                Write(x + ":");
            WriteLine();


            WriteLine("Finished");
            ReadLine();
        }
    }
}
