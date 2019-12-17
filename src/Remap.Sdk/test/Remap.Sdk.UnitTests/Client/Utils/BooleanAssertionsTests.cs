using System;
using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    public class BooleanAssertionsTests
    {
        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Assertion_should_add_filter(string @operator)
        {
            var filters = new List<FilterItem>();
            var subject = new BooleanAssertions("bool", filters);

            if (@operator == "=")
                subject.Be(true);
            else if (@operator == "!=")
                subject.NotBe(true);

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("bool");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().Be("true");
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_thow_api_exception(string @operator)
        {
            BooleanAssertions subject = null;

            Action assertion = null;

            // operators '=' and '!=' can be used with other operators on the same field.
            if (@operator != "=")
                assertion = () => subject.Be(true);
            if (@operator != "!=")
                assertion = () => subject.NotBe(true);

            var filters = new List<FilterItem>(new [] { new FilterItem("bool", @operator, "true") });
            subject = new BooleanAssertions("bool", filters);

            assertion.Should().Throw<ApiException>();
        }

        [Test]
        [TestCase("=", new string[] { "=" })]
        [TestCase("!=", new string[] { "!=" })]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_add_filter_items(string @operator, string[] allowedOperators)
        {
            foreach (var allowedOperator in allowedOperators)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("bool", @operator, "false") });
                var subject = new BooleanAssertions("bool", filters);

                if (allowedOperator == "=")
                    subject.Be(true);
                if (allowedOperator == "!=")
                    subject.NotBe(true);

                filters.Should().HaveCount(2);
                filters[0].Name.Should().Be("bool");
                filters[0].Operator.Should().Be(@operator);
                filters[0].Value.Should().Be("false");
                filters[1].Name.Should().Be("bool");
                filters[1].Operator.Should().Be(allowedOperator);
                filters[1].Value.Should().Be("true");
            }
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Using_Assertion_with_other_Assertions_on_other_member_should_not_be_thow_api_exception(string @operator)
        {
            BooleanAssertions subject = null;

            var assertions = new Action[]
            {
                () => subject.Be(true),
                () => subject.NotBe(true)
            };

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("bool", @operator, "false") });
                subject = new BooleanAssertions("bool1", filters);

                assertion.Should().NotThrow<ApiException>();
            }
        }
    }
}