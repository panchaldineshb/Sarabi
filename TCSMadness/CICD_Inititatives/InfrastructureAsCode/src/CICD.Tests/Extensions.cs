using System;
using Xunit;

namespace Videostore.Domain.Tests
{
    public static class Extensions
    {
        public static void Should_Equal<T>(this IComparable<T> lhs, IComparable<T> rhs)
        {
            Assert.Equal(lhs, rhs);
        }
    }
}