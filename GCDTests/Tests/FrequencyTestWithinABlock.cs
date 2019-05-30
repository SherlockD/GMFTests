/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using Meta.Numerics.Functions;

namespace GCDTests.Tests
{
    public class FrequencyTestWithinABlock : AbstractTest
    {
        public FrequencyTestWithinABlock(byte[] sequence) : base(sequence)
        { }

        public override string GetName => "Frequency Test Within A Block";
        
        public override bool GetResult()
        {
            float[] p = new float[10];
            
            for (int i = 0; i < 100; i += 10)
            {
                p[i/10] = Sequence.GetRange(i, 10).GetNumberOfZeroOrOneBits(GetNumberState.one) / 10f;
            }

            double x2Obs = 0f;

            foreach (var value in p)
            {
                x2Obs += Math.Pow((value - 0.5f), 2);
            }

            x2Obs *= 40;

            var pValue = AdvancedMath.RightRegularizedGamma(10f / 2f, x2Obs / 2f);

            return pValue > 0.01;
        }
    }
}