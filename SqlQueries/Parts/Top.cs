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

        public Top(int top, bool percentage)
        {
            TopCount = top;
            Percentage = percentage;
        }

        public int TopCount { get; set; }

        public bool Percentage { get; set; }


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