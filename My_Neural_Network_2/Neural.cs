using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace My_Neural_Network_2
{
    public class Neural
    {
        double[,] Hidden_Weigth = new double[2, 3 + 1]; //中間層の重み
        double[,] Output_Weigth = new double[2, 2 + 1]; //出力層の重み

        bool DEBUG = false;
        private void D(string s) {
            if (!DEBUG) return;
            Console.WriteLine(s);
        }

        public Neural() {
            //とりあえず、深さ2、ニューロン数3のネットワークを構築
            Random random = new Random();
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 4; j++) {
                    Hidden_Weigth[i, j] = (double)random.Next(0, 1000) / 1000d;
                    D(Hidden_Weigth[i, j].ToString());
                }
            for(int i = 0;i < 2;i++)
                for(int j = 0;j < 3; j++) {
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

                    Update_Weigth(inputData,answerData,Epsilon);
                }
            }
        }

        public void Update_Weigth(double[] input, double[] answer, double Epsilon) {
            Calc(input);

            double[] Output_Delta = {
                (OutputData[0] - answer[0]) * OutputData[0] * (1d - OutputData[0]),
                (OutputData[1] - answer[1]) * OutputData[1] * (1d - OutputData[1])
                };
            /*
            WriteLine("Data:");
            foreach (double x in OutputData)
                Write(x + ":");
            WriteLine();
            */

            //TrainOutput
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++) {
                    Output_Weigth[i, j] -= Epsilon * Output_Delta[i] * ((j == 0) ? 1 : HiddenData[j - 1]); //muはなしで...
                }
            }



            //TrainHidden
            /*
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 4; j++)
                    Write(Hidden_Weigth[i, j] + ":");
                WriteLine();
            }
            WriteLine();
            */

            double[,] Output_Weigth_ = new double[2, 2]; //回切り出した後
            double[,] Output_Weigth__ = new double[2, 2]; //回転後
            for (int i = 0; i < 2; i++)
                for (int j = 1; j < 3; j++)
                    Output_Weigth_[i, j - 1] = Output_Weigth[i, j];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    Output_Weigth__[i, j] = Output_Weigth_[j, i];

            /*
            WriteLine("aa");
            foreach(double x in Output_Delta)
                Write(x + ":");
            WriteLine();
            */
        }

        

        double[] InputData;
        double[] HiddenData;
        double[] OutputData;
        public double[] Calc(double[] Input_) { //__forward
            double[] Input = new double[Input_.Length + 1];
            Input[0] = 1;
            for (int i = 1; i < Input.Length; i++)
                Input[i] = Input[i - 1];

            /*
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 4; j++) {
                    Write(Hidden_Weigth[i, j] + ":");
                }
                WriteLine();
            }
            WriteLine("Weigth");
            foreach (double x in Input)
                Write(x + ":");
            WriteLine("Input");
            */

            InputData = (double[])Input.Clone();
            double[] HiddenData_ = new double[]{
                Math.In_Product(InputData,Math.Dimension_Down(Hidden_Weigth,0)),
                Math.In_Product(InputData, Math.Dimension_Down(Hidden_Weigth, 1))
            };

            WriteLine("HiddenData:");
            foreach (double x in Math.Dimension_Down(Hidden_Weigth, 0))
                Write(x + ":");
            WriteLine();
            foreach (double x in Math.Dimension_Down(Hidden_Weigth, 1))
                Write(x + ":");
            WriteLine();
            WriteLine(Math.In_Product(InputData, Math.Dimension_Down(Hidden_Weigth, 0)));

            HiddenData = new double[HiddenData_.Length + 1];
            HiddenData[0] = 1;
            for (int i = 1; i < HiddenData.Length; i++)
                HiddenData[i] = HiddenData_[i - 1];

            OutputData = new double[] {
                Math.In_Product(HiddenData,Math.Dimension_Down(Output_Weigth,0)),
                Math.In_Product(HiddenData, Math.Dimension_Down(Output_Weigth, 1))
            };
            foreach (double x in OutputData)
                Write(x + ":");
            WriteLine();

            return OutputData;
        }

    }
}
