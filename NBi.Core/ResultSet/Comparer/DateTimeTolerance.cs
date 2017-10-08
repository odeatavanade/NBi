﻿using System;
using System.Linq;

namespace NBi.Core.ResultSet.Comparer
{
    public class DateTimeTolerance : Tolerance
    {
        public TimeSpan TimeSpan {get;set;}

        private DateTimeTolerance()
            : base(0.ToString())
        {
            this.TimeSpan = new TimeSpan(0);
        }

        public DateTimeTolerance(TimeSpan value)
            : base(value.ToString())
        {
            if (value.Ticks <= 0)
                throw new ArgumentException("The parameter 'step' must be a value greater than zero.", "step");

            this.TimeSpan = value;
        }

        public static DateTimeTolerance None
        {
            get
            {
                if (none == null)
                    none = new DateTimeTolerance();
                return none;
            }
        }

        private static DateTimeTolerance none;
    }
}
