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

        double[] Errors;
        public void Train(double[][] Input, double[][] Answer,double Epsilon,int epoch) {
            Errors = new double[epoch];
            for(int TrainCount = 0;TrainCount < epoch; TrainCount++) {
                for(int DataCount = 0;DataCount < Input.GetLength(0); DataCount++) {
                    double[] inputData = Input[DataCount];
                    double[] answerData = Answer[DataCount];
                }
            }
        }

        public void Update_Weigth(double[] input,double[] answer,double Epsilon) {
            Calc(input);

            double[] Output_Delta = {
                (OutputData[0] - answer[0]) * OutputData[0] * (1d - OutputData[0]), 
                (OutputData[1] - answer[1]) * OutputData[1] * (1d - OutputData[1])
                };
        }



        double[] InputData;
        double[] HiddenData;
        double[] OutputData;
        public double[] Calc(double[] Input) { //__forward
            InputData = (double[])Input.Clone();
            HiddenData = new double[]{
                Math.In_Product(InputData,Math.Dimension_Down(Hidden_Weigth,0)),
                Math.In_Product(InputData, Math.Dimension_Down(Hidden_Weigth, 1))
            };
            OutputData = new double[] {
                Math.In_Product(HiddenData,Math.Dimension_Down(Output_Weigth,0)),
                Math.In_Product(HiddenData, Math.Dimension_Down(Output_Weigth, 1))
            };
            return OutputData;
        }

    }
}
