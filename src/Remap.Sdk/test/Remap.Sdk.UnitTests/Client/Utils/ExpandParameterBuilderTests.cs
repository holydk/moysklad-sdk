using System.Collections.Generic;
using Confetti.MoySklad.Remap.Client;
using Confetti.MoySklad.Remap.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.UnitTests.Client
{
    internal class TestExpandMetaEntity : MetaEntity
    {
        [Parameter("entity_one_level")]
        public L1TestExpandMetaEntity L1Entity { get; set; }
    }

    internal class L1TestExpandMetaEntity : MetaEntity
    {
        [Parameter("entity_two_level")]
        public L2TestExpandMetaEntity L2Entity { get; set; }
    }

    internal class L2TestExpandMetaEntity : MetaEntity
    {

    }

    public class ExpandParameterBuilderTests
    {
        [Test]
        public void With_should_add_Expander()
        {
            var expanders = new List<string>();
            var subject = new ExpandParameterBuilder<TestExpandMetaEntity>(expanders);

            subject.With(p => p.L1Entity.L2Entity);

            expanders.Should().HaveCount(1);
            expanders[0].Should().Be("entity_one_level.entity_two_level");
        }

        [Test]
        public void Double_With_should_add_Expander_with_two_properties()
        {
            var expanders = new List<string>();
            var subject = new ExpandParameterBuilder<TestExpandMetaEntity>(expanders);

            subject.With(p => p.L1Entity).And.With(p => p.L1Entity.L2Entity);

            expanders.Should().HaveCount(2);
            expanders[0].Should().Be("entity_one_level");
            expanders[1].Should().Be("entity_one_level.entity_two_level");
        }
    }
}