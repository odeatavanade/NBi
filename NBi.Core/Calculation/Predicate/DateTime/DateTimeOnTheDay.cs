﻿using NBi.Core.Scalar.Comparer;
using NBi.Core.Scalar.Casting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Core.Calculation.Predicate.DateTime
{
    class DateTimeOnTheDay : AbstractPredicate
    {
        public DateTimeOnTheDay(bool not)
            :base(not)
        { }

        protected override bool Apply(object x)
        {
            var caster = new DateTimeCaster();
            var dtX = caster.Execute(x);

            return (dtX.TimeOfDay.Ticks) == 0;
        }

        public override string ToString() => $"is on the day";
    }
}
