using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Note_Index
{
    public enum NoteValue
    {
        nv2000 = 2000, nv500 = 500,
        nv200 = 200, nv100 = 100,
        nv50 = 50, nv20 = 20,
        nv10 = 10, Coin = 1
    }

    public static class SendKeys
    {
        /// <summary>
        ///   Sends the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e1 = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Down)
                    { RoutedEvent = Keyboard.KeyDownEvent };
                    InputManager.Current.ProcessInput(e1);
                }
            }
        }
    }


    public static class Calc
    {
        private static readonly List<int> DinomList = new List<int> { 2000, 500, 200, 100, 50, 20, 10, 1 };

        public static string GetString(this int Valu)
        {
            return Valu == 0 ? "" : Valu.ToString();
        }

        public static string GetINRformat(this int Value)
        {
            string ret_Val = Value.ToString();
            string number = Value.ToString();

            if (number.Length > 7)
            {
                ret_Val = ret_Val.Insert(number.Length - 3, ",");
                ret_Val = ret_Val.Insert(number.Length - 5, ",");
                ret_Val = ret_Val.Insert(number.Length - 7, ",");
                return ret_Val;
            }
            else if (number.Length > 5)
            {
                ret_Val = ret_Val.Insert(number.Length - 3, ",");
                ret_Val = ret_Val.Insert(number.Length - 5, ",");
                return ret_Val;
            }
            else if (number.Length > 3)
            {
                ret_Val = ret_Val.Insert(number.Length - 3, ",");
                return ret_Val;
            }
            else
                return ret_Val == "0" ? "" : ret_Val;

        }

        public static int MultipliedValue(int value, NoteValue nv)
        {
            return value * (int)nv;
        }

        public static int GetInt(this string valu)
        {
           return Convert.ToInt32(valu != string.Empty ? valu : "0");
        }

        public static int CalculateSum(List<int> valu)
        {
            int temp = 0;
            for (int i = 0; i < 8; i++)
                temp += DinomList[i] * valu[i];

            return temp;
        }
    }
}
