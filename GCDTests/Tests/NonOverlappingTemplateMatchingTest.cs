/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Meta.Numerics.Functions;

namespace GCDTests.Tests
{
    public class NonOverlappingTemplateMatchingTest : AbstractTest
    {
        public NonOverlappingTemplateMatchingTest(byte[] sequence) : base(sequence)
        { }

        public override string GetName => "Non Overlapping Template Matching Test";
        
        public override bool GetResult()
        {
            List<byte> pattern = new List<byte>() {0,0,1};
            
            List<List<byte>> sequenceSplit = new List<List<byte>>();

            for (int i = 0; i < Sequence.Count; i += 10)
            {
                sequenceSplit.Add(Sequence.GetRange(i, 10));
            }

            List<int> w = new List<int>();
            
            foreach (var block in sequenceSplit)
            {
                w.Add(GetCountOfPatten(block,pattern));
            }

            double nu = (10 - 3 + 1) / Math.Pow(2, 3);

            double delta2 = 10 * (1 / Math.Pow(2, 3) - ((2 * 3 - 1) / Math.Pow(2, 2 * 3)));

            double x2Obs = (Math.Pow(w[0] - delta2, 2) + Math.Pow(w[1] - delta2, 2)) / Math.Pow(delta2, 2);

            var pValue = AdvancedMath.RightRegularizedGamma(10f / 2f, x2Obs / 2f);

            return pValue > 0.01f;
        }

        private int GetCountOfPatten(List<byte> owner, List<byte> pattern)
        {
            int result = 0;
            
            for (int i = 0; i < owner.Count; i++)
            {
                if (i + pattern.Count > owner.Count)
                {
                    return result;
                }

                if (ListEquals(owner.GetRange(i, pattern.Count),pattern))
                {
                    result++;
                }
            }

            return result;
        }

        private bool ListEquals(List<byte> one, List<byte> two)
        {
            for (int i = 0; i < one.Count; i++)
            {
                if (one[i] != two[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}