﻿using NBi.Core.Assemblies;
using NBi.Core.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBi.Core.Query.Resolver
{
    class AssemblyQueryResolver : IQueryResolver
    {
        private readonly AssemblyQueryResolverArgs args;

        public AssemblyQueryResolver(AssemblyQueryResolverArgs args)
        { 
            this.args = args;
        }

        public IQuery Execute()
        {
            var assemblyManager = new AssemblyManager();
            object methodExecution = null;
            if (args.IsStatic)
            {
                var type = assemblyManager.GetStatic(args.Path, args.ClassName);
                methodExecution = assemblyManager.ExecuteStatic(type, args.MethodName, args.MethodParameters);
            }
            else
            {
                var classInstance = assemblyManager.GetInstance(args.Path, args.ClassName, null);
                methodExecution = assemblyManager.Execute(classInstance, args.MethodName, args.MethodParameters);
            }

            if (!(methodExecution is string)) //It means that we've a query
                throw new InvalidOperationException("The method should return a string (query)");

            var query = new Query( methodExecution as string, args.ConnectionString, args.Timeout, args.Parameters, args.Variables);

            return query;
        }
    }
}
