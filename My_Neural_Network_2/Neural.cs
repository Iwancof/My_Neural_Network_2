using System;
using System.Collections.Generic;
using System.Text;

namespace My_Neural_Network_2
{
    public class Neural
    {
        double[,] Hidden_Weigth = new double[2, 3]; //中間層の重み
        double[,] Output_Weigth = new double[2, 2]; //出力層の重み

        bool DEBUG = true;
        private void D(string s) {
            if (!DEBUG) return;
            Console.WriteLine(s);
        }

        public Neural() {
            //とりあえず、深さ2、ニューロン数3のネットワークを構築
            Random random = new Random();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 3; j++) {
                    Hidden_Weigth[i, j] = (double)random.Next(0, 1000) / 1000d;
                    D(Hidden_Weigth[i, j].ToString());
                }
            for(int i = 0;i < 2;i++)
                for(int j = 0;j < 2; j++) {
                    Output_Weigth[i, j] = (double)random.Next(0, 1000) / 1000d;
                    D(Output_Weigth[i, j].ToString());
                }
        }
    }
}
