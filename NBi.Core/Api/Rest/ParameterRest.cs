﻿using NBi.Core.Scalar.Resolver;
using NBi.Extensibility.Resolving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Core.Api.Rest
{
    public class ParameterRest
    {
        public IScalarResolver<string> Name { get; }
        public IScalarResolver<string> Value { get; }

        public ParameterRest(IScalarResolver<string> name, IScalarResolver<string> value)
            => (Name, Value) = (name, value);
    }
}
