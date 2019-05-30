/* Copyright (C) 2019 Dmitry Andreev
 
 This program was developed by Dmitry Andreev
*/

using System.Collections.Generic;
using System.Linq;

namespace GCDTests
{
    public abstract class AbstractTest
    {
        protected List<byte> Sequence;
        
        public AbstractTest(byte[] sequence)
        {
            Sequence = sequence.ToList();
        }

        public abstract string GetName { get; }
        public abstract bool GetResult();
    }
}