using System;
using static System.Console;

namespace My_Neural_Network_2
{
    class Program
    {
        static void Main(string[] args) {
            Neural n = new Neural();
            n.Update_Weigth(new double[] { 1, 1, 0 }, new double[] { 1, 0, 0 }, 0.1);

            WriteLine("Finished");
            ReadLine();
        }
    }
}
