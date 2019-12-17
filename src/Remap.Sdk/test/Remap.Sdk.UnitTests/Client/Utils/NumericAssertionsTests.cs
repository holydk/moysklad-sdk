using System;
using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    public class NumericAssertionsTests
    {
        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        [TestCase("<")]
        [TestCase(">")]
        [TestCase("<=")]
        [TestCase(">=")]
        public void Assertion_should_add_filter(string @operator)
        {
            var filters = new List<FilterItem>();
            var subject = new NumericAssertions<int>("count", filters);

            if (@operator == "=")
                subject.Be(5);
            else if (@operator == "!=")
                subject.NotBe(5);
            else if (@operator == "<")
                subject.BeLessThan(5);
            else if (@operator == ">")
                subject.BeGreaterThan(5);
            else if (@operator == "<=")
                subject.BeLessOrEqualTo(5);
            else if (@operator == ">=")
                subject.BeGreaterOrEqualTo(5);

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("count");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().Be("5");
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        [TestCase("<")]
        [TestCase(">")]
        [TestCase("<=")]
        [TestCase(">=")]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_thow_api_exception(string @operator)
        {
            NumericAssertions<int> subject = null;

            var assertions = new List<Action>();

            if (@operator != "=")
                assertions.Add(() => subject.Be(5));
            if (@operator != "!=")
                assertions.Add(() => subject.NotBe(5));

            if (@operator == "<" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeLessThan(5));
            if (@operator == ">" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeGreaterThan(5));
            if (@operator == "<=" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeLessOrEqualTo(5));
            if (@operator == ">=" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeGreaterOrEqualTo(5));

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("count", @operator, "6") });
                subject = new NumericAssertions<int>("count", filters);

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
                var filters = new List<FilterItem>(new [] { new FilterItem("count", @operator, "6") });
                var subject = new NumericAssertions<int>("count", filters);

                if (allowedOperator == "=")
                    subject.Be(5);
                if (allowedOperator == "!=")
                    subject.NotBe(5);
                if (allowedOperator == "<")
                    subject.BeLessThan(5);
                if (allowedOperator == ">")
                    subject.BeGreaterThan(5);
                if (allowedOperator == "<=")
                    subject.BeLessOrEqualTo(5);
                if (allowedOperator == ">=")
                    subject.BeGreaterOrEqualTo(5);

                filters.Should().HaveCount(2);
                filters[0].Name.Should().Be("count");
                filters[0].Operator.Should().Be(@operator);
                filters[0].Value.Should().Be("6");
                filters[1].Name.Should().Be("count");
                filters[1].Operator.Should().Be(allowedOperator);
                filters[1].Value.Should().Be("5");
            }
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        [TestCase("<")]
        [TestCase(">")]
        [TestCase("<=")]
        [TestCase(">=")]
        public void Using_Assertion_with_other_Assertions_on_other_member_should_not_be_thow_api_exception(string @operator)
        {
            NumericAssertions<int> subject = null;

            var assertions = new Action[]
            {
                () => subject.Be(5),
                () => subject.NotBe(5),
                () => subject.BeLessThan(5),
                () => subject.BeGreaterThan(5),
                () => subject.BeLessOrEqualTo(5),
                () => subject.BeGreaterOrEqualTo(5)
            };

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("count", @operator, "6") });
                subject = new NumericAssertions<int>("count1", filters);

                assertion.Should().NotThrow<ApiException>();
            }
        }
    }
}