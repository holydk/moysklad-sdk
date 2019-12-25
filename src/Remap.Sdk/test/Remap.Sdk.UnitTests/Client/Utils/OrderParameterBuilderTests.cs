using System;
using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using Confetti.MoySklad.Remap.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    internal class TestMetaEntity : MetaEntity
    {
        [Parameter("stringproperty")]
        public string StringProperty { get; set; }

        public NestedTestMetaEntity NestedEntity { get; set; }
    }

    internal class NestedTestMetaEntity : MetaEntity
    {

    }
    
    public class OrderParameterBuilderTests
    {
        [Test]
        public void By_should_add_Order()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            subject.By(p => p.StringProperty);

            orders.Should().HaveCount(1);
            orders["stringproperty"].Should().Be(OrderBy.Asc);
        }

        [Test]
        public void Double_By_should_add_Order_by_two_properties()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            subject.By(p => p.StringProperty).And.By(p => p.Name, OrderBy.Desc);

            orders.Should().HaveCount(2);
            orders["stringproperty"].Should().Be(OrderBy.Asc);
            orders["name"].Should().Be(OrderBy.Desc);
        }

        [Test]
        public void By_with_nested_parameters_should_throw_api_exception()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            Action action = () => subject.By(p => p.NestedEntity.Name);
            
            action.Should().Throw<ApiException>();
        }
    }
}