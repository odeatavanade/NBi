﻿using NBi.Extensibility.Resolving;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Core.Calculation.Predicate.Text
{
    class TextMoreThanOrEqual : AbstractPredicateReference
    {
        public TextMoreThanOrEqual(bool not, IScalarResolver reference) : base(not, reference)
        { }

        protected override bool ApplyWithReference(object reference, object x)
        {
            var cpr = StringComparer.Create(CultureInfo.InvariantCulture, false);
            return cpr.Compare(x.ToString(), reference.ToString()) >= 0;
        }

        public override string ToString()
        {
            return $"is alphabetically after '{Reference.Execute()}' or equal to it";
        }
    }
}
