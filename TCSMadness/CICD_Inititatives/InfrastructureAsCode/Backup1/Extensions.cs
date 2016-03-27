using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Videostore.Domain.Tests
{
    public static class Extensions
    {
        public static void Should_Equal<T>(this IComparable<T> lhs, IComparable<T> rhs)
        {
            Assert.AreEqual(lhs,rhs);
        }
    }
}
