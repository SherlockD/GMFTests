/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using System.Collections.Generic;
using Meta.Numerics.Functions;

namespace GCDTests.Tests
{
    public enum CounterState
    {
        LessThen,
        Equal,
        MoreThen
    }
    
    public class TestForThelongestRunOfOnesInABlock : AbstractTest
    {
        public TestForThelongestRunOfOnesInABlock(byte[] sequence) : base(sequence)
        { }

        private const int R = 16;
        private const double p0 = 0.2148f;
        private const double p1 = 0.3672f;
        private const double p2 = 0.2305f;
        private const double p3 = 0.1875f;
               
        public override string GetName => "Test For The longest Run Of Ones In A Block";
        
        public override bool GetResult()
        {
            List<List<byte>> blocks = new List<List<byte>>();
            
            for (int i = 0; i < Sequence.Count; i+=8)
            {
                blocks.Add(Sequence.GetRange(i,8));
            }
            
            List<int> maxBlockOneCount = new List<int>();

            foreach (var sequence in blocks)
            {
                maxBlockOneCount.Add(sequence.MaxOneSequence());
            }

            double v0 = CountOfBlocksWithLength(maxBlockOneCount, 1, CounterState.LessThen);
            double v1 = CountOfBlocksWithLength(maxBlockOneCount, 2, CounterState.Equal);
            double v2 = CountOfBlocksWithLength(maxBlockOneCount, 3, CounterState.Equal);
            double v3 = CountOfBlocksWithLength(maxBlockOneCount, 4, CounterState.MoreThen);

            double x2Obs = (Math.Pow(v0 - R * p0, 2)/ (R * p0)) + (Math.Pow(v1 - R * p1, 2)/ (R * p1)) + (Math.Pow(v2 - R * p2, 2)/ (R * p2)) + (Math.Pow(v3 - R * p3, 2)/ (R * p3));

            var pValue = AdvancedMath.RightRegularizedGamma(3f / 2f, x2Obs / 2f);

            return pValue > 0.01;
        }

        private int CountOfBlocksWithLength(List<int> counters ,int length, CounterState state)
        {
            int result = 0;
            
            foreach (var counter in counters)
            {
                switch (state)
                {
                        case CounterState.Equal:
                            if (counter == length)
                            {
                                result++;
                            }

                            break;
                        case CounterState.LessThen:
                            if (counter <= length)
                            {
                                result++;
                            }

                            break;
                        case CounterState.MoreThen:
                            if (counter >= length)
                            {
                                result++;
                            }

                            break;
                }
            }

            return result;
        }
    }
}