/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using Meta.Numerics.Functions;

namespace GCDTests.Tests
{
    public class FrequencyMonobit : AbstractTest
    {
        public override string GetName => "Frequency Monobit";
        
        public FrequencyMonobit(byte[] sequence) : base(sequence)
        { }
        
        public override bool GetResult()
        {
            var n0 = Sequence.GetNumberOfZeroOrOneBits(GetNumberState.zero);
            var n1 = Sequence.GetNumberOfZeroOrOneBits(GetNumberState.one);

            var s = n1 - n0;

            var sObs = Math.Abs(s) / Math.Sqrt(100);

            var pValue = AdvancedMath.Erfc(sObs/Math.Sqrt(2));

            return pValue > 0.01f;
        }
      
    }
}