using System;
using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    public class CustomAssertionsTests
    {
        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        [TestCase("~")]
        [TestCase("~=")]
        [TestCase("=~")]
        [TestCase("<")]
        [TestCase(">")]
        [TestCase("<=")]
        [TestCase(">=")]
        public void Assertion_should_add_filter(string @operator)
        {
            var filters = new List<FilterItem>();
            var subject = new CustomAssertions("name", filters);

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
            else if (@operator == "<")
                subject.BeLessThan("test");
            else if (@operator == ">")
                subject.BeGreaterThan("test");
            else if (@operator == "<=")
                subject.BeLessOrEqualTo("test");
            else if (@operator == ">=")
                subject.BeGreaterOrEqualTo("test");

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
        [TestCase("<")]
        [TestCase(">")]
        [TestCase("<=")]
        [TestCase(">=")]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_thow_api_exception(string @operator)
        {
            CustomAssertions subject = null;

            var assertions = new List<Action>
            {
                () => subject.Contains("test1"),
                () => subject.StartsWith("test1"),
                () => subject.EndsWith("test1"),
            };

            if (@operator != "=")
                assertions.Add(() => subject.Be("test1"));
            if (@operator != "!=")
                assertions.Add(() => subject.NotBe("test1"));
            if (@operator != ">" && @operator != "<=" && @operator != ">=")
                assertions.Add(() => subject.BeLessThan("test1"));
            if (@operator != "<" && @operator != "<=" && @operator != ">=")
                assertions.Add(() => subject.BeGreaterThan("test1"));
            if (@operator != ">" && @operator != "<" && @operator != ">=")
                assertions.Add(() => subject.BeLessOrEqualTo("test1"));
            if (@operator != ">" && @operator != "<" && @operator != "<=")
                assertions.Add(() => subject.BeGreaterOrEqualTo("test1"));

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("name", @operator, "test") });
                subject = new CustomAssertions("name", filters);

                assertion.Should().Throw<ApiException>();
            }
        }

        [Test]
        [TestCase("=", new string[] { "=" })]
        [TestCase("!=", new string[] { "!=" })]
        [TestCase("<", new string[] { ">", "<=", ">=" })]
        [TestCase(">", new string[] { "<", "<=", ">=" })]
        [TestCase("<=", new string[] { ">=", "<", ">" })]
        [TestCase(">=", new string[] { "<=", "<", ">" })]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_add_filter_items(string @operator, string[] allowedOperators)
        {
            foreach (var allowedOperator in allowedOperators)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("name", @operator, "test") });
                var subject = new CustomAssertions("name", filters);

                if (allowedOperator == "=")
                    subject.Be("test1");
                if (allowedOperator == "!=")
                    subject.NotBe("test1");
                if (allowedOperator == "<")
                    subject.BeLessThan("test1");
                if (allowedOperator == ">")
                    subject.BeGreaterThan("test1");
                if (allowedOperator == "<=")
                    subject.BeLessOrEqualTo("test1");
                if (allowedOperator == ">=")
                    subject.BeGreaterOrEqualTo("test1");

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
        [TestCase("<")]
        [TestCase(">")]
        [TestCase("<=")]
        [TestCase(">=")]
        public void Using_Assertion_with_other_Assertions_on_other_member_should_not_be_thow_api_exception(string @operator)
        {
            CustomAssertions subject = null;

            var assertions = new Action[]
            {
                () => subject.Be("test1"),
                () => subject.NotBe("test1"),
                () => subject.Contains("test1"),
                () => subject.StartsWith("test1"),
                () => subject.EndsWith("test1"),
                () => subject.BeLessThan("test1"),
                () => subject.BeGreaterThan("test1"),
                () => subject.BeLessOrEqualTo("test1"),
                () => subject.BeGreaterOrEqualTo("test1")
            };

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("name", @operator, "test") });
                subject = new CustomAssertions("name1", filters);

                assertion.Should().NotThrow<ApiException>();
            }
        }
    }
}