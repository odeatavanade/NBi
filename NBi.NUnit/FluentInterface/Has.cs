﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NBiMember = NBi.NUnit.Member;
using NBiStructure = NBi.NUnit.Structure;
using NF = NUnit.Framework;

namespace NBi.NUnit.FluentInterface
{
    public class Has : NF.Has
    {
        public Has()
        {
        }

        public static NBiMember.ContainConstraint Member(string value)
        {
            var ctr = new NBiMember.ContainConstraint(value);
            return ctr;
        }

        public static NBiMember.ContainConstraint Members(IEnumerable<string> values)
        {
            var ctr = new NBiMember.ContainConstraint(values);
            return ctr;
        }

        public new static NBiMember.CountConstraint Exactly(int count)
        {
            var ctr = new NBiMember.CountConstraint();
            ctr.Exactly(count);
            return ctr;
        }

        public static NBiMember.CountConstraint MoreThan(int count)
        {
            var ctr = new NBiMember.CountConstraint();
            ctr.MoreThan(count);
            return ctr;
        }

        public static NBiMember.CountConstraint LessThan(int count)
        {
            var ctr = new NBiMember.CountConstraint();
            ctr.LessThan(count);
            return ctr;
        }

        public static NBiStructure.ContainConstraint Item(string value)
        {
            var ctr = new NBiStructure.ContainConstraint(value);
            return ctr;
        }

        public static NBiStructure.EquivalentToConstraint ExactlyItems(IEnumerable<string> values)
        {
            var ctr = new NBiStructure.EquivalentToConstraint(values);
            return ctr;
        }
    }
}
