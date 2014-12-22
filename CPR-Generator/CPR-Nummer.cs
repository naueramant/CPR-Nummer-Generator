using System;
using System.Collections.Generic;

//  This class is for education purpose only 
//  and shall not be used for malicious intent
//
//  Author: Jonas Tranberg (2014)

namespace CPR
{
    class CPR_utilities
    {
        private static string CPR;
        private static int[] ControlNumers = new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        //Get gender
        public static bool Gender(string _CPR) 
        {
            _CPR = _CPR.Replace("-", "");
            if (IsEven(_CPR[9] - 48) != true) { return true; } else { return false; }; //if true then male
        }

        //Validate the CPR number
        public static bool Validate(string _CPR)
        {
            _CPR = _CPR.Replace("-", "");
            int sum = 0;
            for (int i = 0; i < _CPR.Length - 1; i++)
            {
                sum += (_CPR[i] - 48) * ControlNumers[i];
            }
            if (sum % 11 == 11 - (_CPR[9] - 48)) { return true; } else { return false; }
        }

        public static string Generate(DateTime _Birthday, bool _Male, bool _Hyphen)
        {
        START:
            CPR = null;
            int sum = 0;
            int temp_digit_7;

            CPR = _Birthday.ToString("ddMMyy");

            temp_digit_7 = Make_Digit_7(_Birthday);

            if (temp_digit_7 == -1) { return null; }

            CPR += temp_digit_7;

            Random Roller = new Random();

            for (int i = 0; i < 2; i++)
            {
                CPR += Roller.Next(0, 10);
            }

            for (int i = 0; i < CPR.Length; i++)
            {
                sum += (CPR[i] - 48) * ControlNumers[i];
            }

            if ((11 - (sum % 11)) == 11 | (11 - (sum % 11)) == 10)
            {
                goto START;
            }
            if (IsEven(11 - (sum % 11)) == _Male)
            {
                goto START;
            }

            CPR += 11 - (sum % 11);

            if (_Hyphen)
            { return CPR.Insert(6, "-"); }

            return CPR;
        }

        //Generate digit 7
        private static int Make_Digit_7(DateTime _Birthday)
        {

            Random Roller = new Random();

            int year = Convert.ToInt32(_Birthday.ToString("yyyy"));

            if (year < 1858)
            {
                return -1;
            }

            if (year > 2057)
            {
                return -1;
            }

            if (year < 1900)
            {
                return Roller.Next(5, 9);
            }

            if (year <= 1999)
            {
                if (year < 1937)
                {
                    return Roller.Next(0, 4);
                }
                if (year >= 1937)
                {
                    List<int> Choices = new List<int> { 0, 1, 2, 3, 4, 9 };
                    return Choices[Roller.Next(0, 6)];
                }
            }

            if (year <= 2057)
            {
                if (year <= 2036)
                {
                    return Roller.Next(4, 10);
                }
                if (year > 2036)
                {
                    return Roller.Next(5, 9);
                }
            }

            return -1;
        }

        //Check if a number is even
        private static bool IsEven(int Number)
        {
            if ((Number % 2) == 0) { return true; } else { return false; }
        }
    }
}
