using System;
using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    public class StringAssertionsTests
    {
        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        [TestCase("~")]
        [TestCase("~=")]
        [TestCase("=~")]
        public void Assertion_should_add_filter(string @operator)
        {
            var filters = new List<FilterItem>();
            var subject = new StringAssertions("name", filters);

            if (@operator == "=")
                subject.Be("test");
            else if (@operator == "!=")
                subject.NotBe("test");
            else if (@operator == "~")
                subject.Contains("test");
            else if (@operator == "~=")
                subject.StartsWith("test");
            else if (@operator == "=~")
                subject.EndsWith("test");

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("name");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().Be("test");
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        [TestCase("~")]
        [TestCase("~=")]
        [TestCase("=~")]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_thow_api_exception(string @operator)
        {
            StringAssertions subject = null;

            var assertions = new List<Action>
            {
                () => subject.Contains("test1"),
                () => subject.StartsWith("test1"),
                () => subject.EndsWith("test1")
            };

            // operators '=' and '!=' can be used with other operators on the same field.
            if (@operator != "=")
                assertions.Add(() => subject.Be("test1"));
            if (@operator != "!=")
                assertions.Add(() => subject.NotBe("test1"));

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("name", @operator, "test") });
                subject = new StringAssertions("name", filters);

                assertion.Should().Throw<ApiException>();
            }
        }

        [Test]
        [TestCase("=", new string[] { "=" })]
        [TestCase("!=", new string[] { "!=" })]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_add_filter_items(string @operator, string[] allowedOperators)
        {
            foreach (var allowedOperator in allowedOperators)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("name", @operator, "test") });
                var subject = new StringAssertions("name", filters);

                if (allowedOperator == "=")
                    subject.Be("test1");
                if (allowedOperator == "!=")
                    subject.NotBe("test1");

                filters.Should().HaveCount(2);
                filters[0].Name.Should().Be("name");
                filters[0].Operator.Should().Be(@operator);
                filters[0].Value.Should().Be("test");
                filters[1].Name.Should().Be("name");
                filters[1].Operator.Should().Be(allowedOperator);
                filters[1].Value.Should().Be("test1");
            }
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        [TestCase("~")]
        [TestCase("~=")]
        [TestCase("=~")]
        public void Using_Assertion_with_other_Assertions_on_other_member_should_not_be_thow_api_exception(string @operator)
        {
            StringAssertions subject = null;

            var assertions = new Action[]
            {
                () => subject.Be("test1"),
                () => subject.NotBe("test1"),
                () => subject.Contains("test1"),
                () => subject.StartsWith("test1"),
                () => subject.EndsWith("test1")
            };

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("name", @operator, "test") });
                subject = new StringAssertions("name1", filters);

                assertion.Should().NotThrow<ApiException>();
            }
        }
    }
}