﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RepeatingkeyVigenere : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            string cipher = cipherText.ToLower();
            string key = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                if (cipher[i] - plainText[i] < 0)
                    key += (char)(122 - plainText[i] + cipher[i]+1);
                else
                    key += (char)(97 + cipher[i] - plainText[i]);

                string temp = Encrypt(plainText, key);
                if (temp.Equals(cipherText))
                    break;
            }

            return key;
        }

        public string Decrypt(string cipherText, string key)
        {
            string plainText = "";
            int keyIndex = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] - (key[keyIndex] - 97) + 32 < 97)
                    plainText += (char)(cipherText[i] - (key[keyIndex] - 97) + 32 + 26);
                else
                    plainText += (char)(cipherText[i] - (key[keyIndex] - 97) + 32);
                keyIndex++;
                if (keyIndex == key.Length)
                    keyIndex = 0;
            }
            return plainText;
        }

        public string Encrypt(string plainText, string key)
        {
            string cipher = "";
            int keyIndex = 0;
            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] + key[keyIndex] - 97 > 122)
                    cipher += (char)(plainText[i] + key[keyIndex] - 97 - 32 - 26);
                else
                    cipher += (char)(plainText[i] + key[keyIndex] - 97 - 32);
                keyIndex++;
                if (keyIndex == key.Length)
                    keyIndex = 0;

            }
            return cipher;
        }
    }
}