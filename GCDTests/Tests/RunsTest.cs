/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using Meta.Numerics.Functions;

namespace GCDTests.Tests
{
    public class RunsTest : AbstractTest
    {
        public RunsTest(byte[] sequence) : base(sequence)
        { }

        public override string GetName => "Runs test";
        
        public override bool GetResult()
        {
            double t = 2 / Math.Sqrt(100);

            double p = Sequence.GetNumberOfZeroOrOneBits(GetNumberState.one) / 100f;

            if (Math.Abs(p - 0.5f) > t)
            {
                return false;
            }

            double vObs = 1;

            for (int i = 1; i < 100 - 1; i++)
            {
                if (Sequence[i] == Sequence[i + 1])
                {
                    vObs += 0;
                }
                else
                {
                    vObs += 1;
                }
            }

            var pValue = AdvancedMath.Erfc((Math.Abs(vObs - 2 * 100 * p * (1 - p))) / (2 * Math.Sqrt(2 * 100) * p * (1 - p)));

            return pValue > 0.01f;
        }
    }
}