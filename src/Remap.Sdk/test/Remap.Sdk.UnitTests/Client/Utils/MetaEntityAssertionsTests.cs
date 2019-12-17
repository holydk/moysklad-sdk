using System;
using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using Confetti.MoySklad.Remap.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    internal class MetaFilterEntity : MetaEntity
    {
        public NestedMetaFilterEntity NestedEntity { get; set; }
    }

    internal class NestedMetaFilterEntity : MetaEntity
    {

    }

    public class MetaEntityAssertionsTests
    {
        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Assertion_should_add_filter(string @operator)
        {
            var filters = new List<FilterItem>();
            var subject = new MetaEntityAssertions("nestedentity", filters);

            if (@operator == "=")
                subject.Be("test_id");
            else if (@operator == "!=")
                subject.NotBe("test_id");

            filters.Should().HaveCount(1);
            filters[0].Name.Should().Be("nestedentity");
            filters[0].Operator.Should().Be(@operator);
            filters[0].Value.Should().Be("test_id");
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_thow_api_exception(string @operator)
        {
            MetaEntityAssertions subject = null;

            Action assertion = null;

            // operators '=' and '!=' can be used with other operators on the same field.
            if (@operator != "=")
                assertion = () => subject.Be("test_id");
            if (@operator != "!=")
                assertion = () => subject.NotBe("test_id");

            var filters = new List<FilterItem>(new [] { new FilterItem("nestedentity", @operator, "test_id_1") });
            subject = new MetaEntityAssertions("nestedentity", filters);

            assertion.Should().Throw<ApiException>();
        }

        [Test]
        [TestCase("=", new string[] { "=" })]
        [TestCase("!=", new string[] { "!=" })]
        public void Using_Assertion_with_other_Assertions_on_same_member_should_be_add_filter_items(string @operator, string[] allowedOperators)
        {
            foreach (var allowedOperator in allowedOperators)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("nestedentity", @operator, "test_id_1") });
                var subject = new MetaEntityAssertions("nestedentity", filters);

                if (allowedOperator == "=")
                    subject.Be("test_id");
                if (allowedOperator == "!=")
                    subject.NotBe("test_id");

                filters.Should().HaveCount(2);
                filters[0].Name.Should().Be("nestedentity");
                filters[0].Operator.Should().Be(@operator);
                filters[0].Value.Should().Be("test_id_1");
                filters[1].Name.Should().Be("nestedentity");
                filters[1].Operator.Should().Be(allowedOperator);
                filters[1].Value.Should().Be("test_id");
            }
        }

        [Test]
        [TestCase("=")]
        [TestCase("!=")]
        public void Using_Assertion_with_other_Assertions_on_other_member_should_not_be_thow_api_exception(string @operator)
        {
            MetaEntityAssertions subject = null;

            var assertions = new Action[]
            {
                () => subject.Be("test_id"),
                () => subject.NotBe("test_id")
            };

            foreach (var assertion in assertions)
            {
                var filters = new List<FilterItem>(new [] { new FilterItem("nestedentity", @operator, "test_id_1") });
                subject = new MetaEntityAssertions("nestedentity1", filters);

                assertion.Should().NotThrow<ApiException>();
            }
        }
    }
}