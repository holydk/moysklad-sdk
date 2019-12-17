using System;
using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    public class DateTimeAssertionsTests
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
            var subject = new DateTimeAssertions("time", filters);

            var now = DateTime.Now;

            if (@operator == "=")
                subject.Be(now);
            else if (@operator == "!=")
                subject.NotBe(now);
            else if (@operator == "<")
                subject.BeLessThan(now);
            else if (@operator == ">")
                subject.BeGreaterThan(now);
            else if (@operator == "<=")
                subject.BeLessOrEqualTo(now);
            else if (@operator == ">=")
                subject.BeGreaterOrEqualTo(now);

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("time");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().Be(now.ToString(Configuration.DEFAULT_DATETIME_FORMAT));
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
            var now = DateTime.Now;

            DateTimeAssertions subject = null;
            var assertions = new List<Action>();

            if (@operator != "=")
                assertions.Add(() => subject.Be(now));
            if (@operator != "!=")
                assertions.Add(() => subject.NotBe(now));

            if (@operator == "<" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeLessThan(now));
            if (@operator == ">" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeGreaterThan(now));
            if (@operator == "<=" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeLessOrEqualTo(now));
            if (@operator == ">=" || @operator == "=" || @operator == "!=")
                assertions.Add(() => subject.BeGreaterOrEqualTo(now));

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("time", @operator, DateTime.Now.ToString()) });
                subject = new DateTimeAssertions("time", filters);

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
            var now = DateTime.Now;

            foreach (var allowedOperator in allowedOperators)
            {
                var filterTime = DateTime.Now.ToString();
                var filters = new List<FilterItem>(new [] { new FilterItem("time", @operator, filterTime) });
                var subject = new DateTimeAssertions("time", filters);

                if (allowedOperator == "=")
                    subject.Be(now);
                if (allowedOperator == "!=")
                    subject.NotBe(now);
                if (allowedOperator == "<")
                    subject.BeLessThan(now);
                if (allowedOperator == ">")
                    subject.BeGreaterThan(now);
                if (allowedOperator == "<=")
                    subject.BeLessOrEqualTo(now);
                if (allowedOperator == ">=")
                    subject.BeGreaterOrEqualTo(now);

                filters.Should().HaveCount(2);
                filters[0].Name.Should().Be("time");
                filters[0].Operator.Should().Be(@operator);
                filters[0].Value.Should().Be(filterTime);
                filters[1].Name.Should().Be("time");
                filters[1].Operator.Should().Be(allowedOperator);
                filters[1].Value.Should().Be(now.ToString(Configuration.DEFAULT_DATETIME_FORMAT));
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
            var now = DateTime.Now;

            DateTimeAssertions subject = null;

            var assertions = new Action[]
            {
                () => subject.Be(now),
                () => subject.NotBe(now),
                () => subject.BeLessThan(now),
                () => subject.BeGreaterThan(now),
                () => subject.BeLessOrEqualTo(now),
                () => subject.BeGreaterOrEqualTo(now)
            };

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("time", @operator, DateTime.Now.ToString()) });
                subject = new DateTimeAssertions("time1", filters);

                assertion.Should().NotThrow<ApiException>();
            }
        }
    }
}