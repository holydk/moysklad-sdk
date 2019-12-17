using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    public class NullableBooleanAssertionsTests
    {
        [Test]
        public void BeNull_should_add_filter()
        {
            var filters = new List<FilterItem>();
            var subject = new NullableBooleanAssertions("bool", filters);

            subject.BeNull();

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("bool");
            filters[0].Operator.Should().Be("=");
            filters[0].Value.Should().Be(string.Empty);
        }

        [Test]
        public void NotBeNull_should_add_filter()
        {
            var filters = new List<FilterItem>();
            var subject = new NullableBooleanAssertions("bool", filters);

            subject.NotBeNull();

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("bool");
            filters[0].Operator.Should().Be("!=");
            filters[0].Value.Should().Be(string.Empty);
        }
    }
}