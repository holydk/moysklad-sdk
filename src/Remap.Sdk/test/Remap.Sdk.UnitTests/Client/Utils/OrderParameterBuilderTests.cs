using System;
using System.Collections.Generic;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.UnitTests.Client
{
    internal class TestMetaEntity
    {
        [AllowOrder]
        [Parameter("stringproperty")]
        public string StringProperty { get; set; }

        [AllowOrder]
        [Parameter("intproperty")]
        public string IntProperty { get; set; }

        [Parameter("notAllowedOrderMember")]
        public string NotAllowedOrderMember { get; set; }

        public NestedTestMetaEntity NestedEntity { get; set; }
    }

    internal class NestedTestMetaEntity
    {
        [AllowOrder]
        [Parameter("stringproperty")]
        public string StringProperty { get; set; }
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

            subject.By(p => p.StringProperty).And.By(p => p.IntProperty, OrderBy.Desc);

            orders.Should().HaveCount(2);
            orders["stringproperty"].Should().Be(OrderBy.Asc);
            orders["intproperty"].Should().Be(OrderBy.Desc);
        }

        [Test]
        public void By_with_nested_parameters_should_throw_api_exception()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            Action action = () => subject.By(p => p.NestedEntity.StringProperty);
            
            action.Should().Throw<ApiException>();
        }

        [Test]
        public void If_order_is_not_allowed_then_By_should_throw_api_exception()
        {
            var orders = new Dictionary<string, OrderBy>();
            var subject = new OrderParameterBuilder<TestMetaEntity>(orders);

            Action action = () => subject.By(p => p.NotAllowedOrderMember);
            
            action.Should().Throw<ApiException>();
        }
    }
}