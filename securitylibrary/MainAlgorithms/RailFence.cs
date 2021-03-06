﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {
            int key = 2;
            double length = plainText.Length;
            for (int k = 0; k <= 100; k++)
            {
                double coldouble = length / key;
                int col_num = (int)Math.Ceiling(coldouble);
                string cipherTexttemp = "";
                int counter = 0;
                char[,] table = new char[key, col_num];
                for (int j = 0; j < col_num; j++)
                {
                    for (int i = 0; i < key; i++)
                    {
                        if (counter >= length)
                        {
                            table[i, j] = 'x';
                        }
                        else
                        {
                            table[i, j] = plainText[counter];
                            counter++;
                        }
                    }
                }
                for (int i = 0; i < key; i++)
                {
                    for (int j = 0; j < col_num; j++)
                    {
                        if ((j + 1) * (i + 1) > length)
                        {
                            break;
                        }
                        else
                        {
                            if (table[i, j] == 'x')
                            {
                                continue;
                            }
                            else
                            {
                                cipherTexttemp += table[i, j];
                            }
                        }
                    }
                }
                if (cipherTexttemp.ToUpper() == cipherText)
                {
                    break;
                }
                else
                {
                    key++;
                }
            }
            return key;
        }

        public string Decrypt(string cipherText, int key)
        {
            double length = cipherText.Length;
            double coldouble = length / key;
            int col_num = (int)Math.Ceiling(coldouble);
            string plainText = "";
            int counter = 0;
            char[,] table = new char[key, col_num];
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < col_num; j++)
                {
                    if (counter >= length)
                    {
                        break;
                    }
                    table[i,j] = cipherText[counter];
                    counter++;
                }
            }
            for (int j = 0; j < col_num; j++)
            {
                for (int i = 0; i < key; i++)
                {
                    if ((j + 1) * (i + 1) > length)
                    {
                        break;
                    }
                    else
                    {
                        plainText += table[i, j];
                    }
                }
            }
            return plainText.ToLower() ;
        }

        public string Encrypt(string plainText, int key)
        {
            double length = plainText.Length;
            double coldouble = length / key;
            int  col_num = (int) Math.Ceiling(coldouble);
            string cipherText = "";
            int counter = 0;
            char[,] table = new char[key, col_num];
            for (int j = 0; j < col_num; j++) {
                for (int i = 0; i < key; i++) {
                    if (counter >= length)
                    {
                        break;
                    }
                    else
                    {
                        table[i, j] = plainText[counter];
                        counter++;
                    }
                }
            }
            for (int i = 0; i < key; i++) {
                for (int j = 0; j < col_num; j++) {
                    if ((j + 1) * (i + 1) > length) {
                        break;
                    }
                    cipherText += table[i, j];
                }
            }
            return cipherText.ToUpper();
        }
    }
}
