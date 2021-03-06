﻿using NBi.Core.Decoration.DataEngineering;
using NBi.Extensibility.Resolving;
using NBi.Core.Scalar.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Core.Decoration.DataEngineering
{
    public interface IConnectionWaitCommandArgs : IDataEngineeringCommandArgs
    {
        IScalarResolver<int> TimeOut { get; }
    }
}
