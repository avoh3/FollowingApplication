﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Following
{
    public class Password
    {
        public static string CryptedPassword(string password)
        {
            return password.GetHashCode().ToString();
        }
        public static string PinCodeGen()
        {
            char[] pin = new char[4];
            string pincode = "0123456789";
            var rnd = new Random();
            for (int i = 0; i < pin.Length; i++)
            {
                pin[i] = (char)pincode[rnd.Next(0, pincode.Length)];
            }
            return Password.ToString(pin);
        }
        public static string NewPassword()
        {
            char[] pin = new char[8];
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            byte[] data = new byte[8];
            var rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                pin[i] = (char)alphabet[rnd.Next(0, alphabet.Length - 1)];
            }
            return Password.ToString(pin);
        }
        private static string ToString(char[] pin)
        {
            string s = String.Empty; ;
            foreach (var m in pin)
                s = s + m;
            return s;
        }
    }
}
