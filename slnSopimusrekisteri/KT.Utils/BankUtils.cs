using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils
{

    public class BankUtils
    {

        private static int[] _defaultWeightCoefficients = { 7, 3, 1 };


        public static long CreateReferenceNumber(long baseNumber)
        {
            return CreateReferenceNumber(baseNumber, _defaultWeightCoefficients);
        }

        public static long CreateReferenceNumber(long baseNumber, int[] weightCoefficients)
        {
            return long.Parse(baseNumber.ToString() + CalculateCheckDigit(baseNumber, weightCoefficients).ToString());
        }

        public static int CalculateCheckDigit(long referenceNumberBase)
        {
            return CalculateCheckDigit(referenceNumberBase, _defaultWeightCoefficients);
        }

        public static int CalculateCheckDigit(long referenceNumberBase, int[] weightCoefficients)
        {
            
            string referenceString = referenceNumberBase.ToString();

            int coefficientIndex = 0;
            int charIndex = 0;
            int coefficient = 0;

            int sum = 0;            

            for (charIndex = referenceString.Length - 1; charIndex >= 0; charIndex += -1)
            {
                coefficient = weightCoefficients[coefficientIndex];

                int currentNumber = Int32.Parse(referenceString[charIndex].ToString());

                sum += currentNumber * coefficient;

                coefficientIndex = GetNextIndex(coefficientIndex, weightCoefficients.Length);
            }

            int modulo = sum % 10;
            if (modulo == 0)
                return 0;
            return 10 - modulo;
        }


        public static bool IsReferenceNumberValid(long referenceNumber)
        {
            return IsReferenceNumberValid(referenceNumber, _defaultWeightCoefficients);
        }

        public static bool IsReferenceNumberValid(long referenceNumber, int[] weightCoefficients)
        {
            string referenceString = referenceNumber.ToString();

            if (string.IsNullOrEmpty(referenceString) || referenceString.Length > 20 || referenceString.Length < 2)
                return false;

            string basePart = referenceString.Substring(0, referenceString.Length - 1);
            return CalculateCheckDigit(long.Parse(basePart), weightCoefficients) == long.Parse(referenceString.Substring(referenceString.Length - 1, 1));
        }

        private static int GetNextIndex(int currentIndex, int arrayLength)
        {
            if ((currentIndex == arrayLength - 1))
                return 0;
            return currentIndex + 1;
        }

    }

}
