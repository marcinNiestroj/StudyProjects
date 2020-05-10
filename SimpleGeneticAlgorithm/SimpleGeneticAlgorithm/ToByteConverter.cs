using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGeneticAlgorithm
{
    public class ToByteConverter
    {
        public ToByteConverter() { }

        public List<StringBuilder> ConvertIntToByte(List<int> fxValues)
        {
            List<StringBuilder> fxValuesInByte = new List<StringBuilder>();

            foreach (int value in fxValues)
            {
                StringBuilder stringBuilder = new StringBuilder(Convert.ToString(value, 2));

                if (stringBuilder.Length < 8)
                {
                    for (int i = stringBuilder.Length; i < 8; i++)
                    {
                        stringBuilder.Insert(0, "0");
                    }
                }
                fxValuesInByte.Add(stringBuilder);
            }
            return fxValuesInByte;
        }
    }
}