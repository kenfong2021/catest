using System;


namespace catest
{
    class Program
    {
        static void Main(string[] args)
        {
            //I choose to place the test data in string instead of
            string sDS1;
            string expectedResult;
            sDS1 = "18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03";
            expectedResult = "15(15.28),21(27.39)";
            getMaxGain(sDS1, expectedResult);

            sDS1 = "22.74,22.27,20.61,26.15,21.68,21.51,19.66,24.11,20.63,20.96,26.56,26.67,26.02,27.20,19.13,16.57,26.71,25.91,17.51,15.79,26.19,18.57,19.03,19.02,19.97,19.04,21.06,25.94,17.03,15.61";
            expectedResult = "20(15.79),21(26.19)";
            getMaxGain(sDS1, expectedResult);

            sDS1 = "";
            expectedResult = "Invalid Input";
            getMaxGain(sDS1, expectedResult);

            sDS1 = ",";
            expectedResult = "Invalid Input";
            getMaxGain(sDS1, expectedResult);

            sDS1 = "2,1";
            expectedResult = "No Best Gain Found";
            getMaxGain(sDS1, expectedResult);

        }
 

        static void getMaxGain(string data, string expectedResult)
        {
            string[] arrDS1 = data.Split(",");

            //check if the input data is comma sperated
            if (arrDS1.Length <=1)
            {
                Console.WriteLine("Expected: " + expectedResult);
                Console.WriteLine("Output:   " + "Invalid Input");
                return;
            }

            double max = -1;
            double min = 9999999;
            double total = 0;
            int minIndex = 0;
            int maxIndex = 0;

            string result = "";
            double tempMax = -1;
            double tempMin = 9999999;
            double tempTotal = 0;
            int tempMinIndex = 0;
            int tempMaxIndex = 0;

            double current = 0;
       


            //insert the data 
            for (int i = 0; i < arrDS1.Length; i++)
            {
                //Try to Parse the current element, return error if not successful
              
                if (Double.TryParse(arrDS1[i], out current))
                { 

                }
                else
                {
                    Console.WriteLine("Expected: " + expectedResult);
                    Console.WriteLine("Output:   " + "Invalid Input");
                    return;
                }
                    

                //if the current element < tempMin, set the tempMax, tempMin, and all index to current, as a start point, tempTotal will be set to zero
                if (current < tempMin)
                {
                    tempMax = current;
                    tempMin = current;
                    tempMaxIndex = i;
                    tempMinIndex = i;
                    tempTotal = tempMax - tempMin;
                }//start from the point above, if the coming element higher than the preview element, update the max and the total
                else if (current > tempMax)
                {
                    tempMax = current;
                    tempMaxIndex = i;
                    tempTotal = tempMax - tempMin;
                }
                //if the total calculated above (tempTotal) higher than the total stored (total), update min, max, total and related index 
                if (tempTotal > total)
                {
                    max = tempMax;
                    min = tempMin;
                    total = tempTotal;
                    maxIndex = tempMaxIndex;
                    minIndex = tempMinIndex;
                }


            }

            //If no best gain found, return the message below
            if (max == -1 && min == 9999999)
            {
                Console.WriteLine("Expected: " + expectedResult);
                Console.WriteLine("Output:   " + "No Best Gain Found");
                return;
            }

            //Index need to be added 1 becuase it started from 0
            result = (minIndex  + 1) + "(" + min + ")," + (maxIndex + 1) + "(" + max + ")";

            Console.WriteLine("Expected: " + expectedResult);
            Console.WriteLine("Output:   " + result);


        }

    }
}
