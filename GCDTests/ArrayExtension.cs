/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using System.Collections.Generic;

namespace GCDTests
{
    public enum GetNumberState
    {
        zero,
        one
    }
    
    public static class Extension
    {
        public static int GetNumberOfZeroOrOneBits(this List<byte> owner,GetNumberState state)
        {
            int result = 0;
            
            switch (state)
            {
                    case GetNumberState.one:
                        foreach (var @byte in owner)
                        {
                            if (@byte == 1) result++;
                        }

                        break;
                    case GetNumberState.zero:
                        foreach (var @byte in owner)
                        {
                            if (@byte == 1) result++;
                        }

                        break;
            }

            return result;
        }

        public static int MaxOneSequence(this List<byte> owner)
        {
            int result = 0;
            int counter = 0;
            
            foreach (var @byte in owner)
            {
                if (@byte == 1)
                {
                    counter++;
                }
                else
                {
                    if (result < counter)
                    {
                        result = counter;
                    }

                    counter = 0;
                }
            }

            return result;
        }
        
        public static double[] DFT(double[] data)
        {
            int n = data.Length;
            int m = n;// I use m = n / 2d;
            double[] real = new double[n];
            double[] imag = new double[n];
            double[] result = new double[m];
            double pi_div = 2.0 * Math.PI / n;
            for (int w = 0; w < m; w++)
            {
                double a = w * pi_div;
                for (int t = 0; t < n; t++)
                {
                    real[w] += data[t] * Math.Cos(a * t);
                    imag[w] += data[t] * Math.Sin(a * t);
                }
                result[w] = Math.Sqrt(real[w] * real[w] + imag[w] * imag[w]) / n;
            }
            return result;
        }
    }
}