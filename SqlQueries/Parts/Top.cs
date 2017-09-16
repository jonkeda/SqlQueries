using System;
using System.Diagnostics;

namespace SqlQueries.Parts
{
    public class Top
    {
        public Top(int top)
        {
            TopCount = top;
        }

        public int TopCount { get; }

        [DebuggerStepThrough]
        public static explicit operator int(Top value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            return value.TopCount;
        }

        public static implicit operator Top(int value)
        {
            return new Top(value);
        }

    }
}