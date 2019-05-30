/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System;
using System.Linq;
using Meta.Numerics.Functions;

namespace GCDTests.Tests
{
    public class SpectralTest : AbstractTest
    {
        public SpectralTest(byte[] sequence) : base(sequence)
        { }

        public override string GetName => "Spectral test";
        
        public override bool GetResult()
        {
            double[] sequenceTransformation = new double[Sequence.Count];

            for (int i = 0; i < Sequence.Count; i++)
            {
                sequenceTransformation[i] = (Sequence[i] == 1)?1:-1;
            }

            var s = Extension.DFT(sequenceTransformation.ToList().GetRange(1,5).ToArray());
            
            double[] m = new double[s.Length];

            for(int i = 0;i < s.Length;i++)
            {
                m[i] = Math.Abs(s[i]);
            }

            var T = Math.Sqrt(3 * Sequence.Count);
            var N0 = (0.95f * Sequence.Count) / 2;

            var N1 = 0;

            foreach (var data in m)
            {
                if (data < T)
                {
                    N1++;
                }
            }

            var d = (N1 - N0) / Math.Sqrt(0.95f * (0.05f / 2f) * Sequence.Count);

            var pValue = AdvancedMath.Erfc(Math.Abs(d) / Math.Sqrt(2));

            return pValue > 0.01;
        }
    }
}