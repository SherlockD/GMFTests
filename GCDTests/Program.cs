/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using GCDTests.Tests;

namespace GCDTests
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintAnswer(new NonOverlappingTemplateMatchingTest(new byte[] {1,0,1,0,0,1,0,0,1,0,1,1,1,0,0,1,0,1,1,0}));
        }

        public static void PrintAnswer(AbstractTest test)
        {
            Console.WriteLine($"{test.GetName} status: {test.GetResult()}");
        }
    }
}