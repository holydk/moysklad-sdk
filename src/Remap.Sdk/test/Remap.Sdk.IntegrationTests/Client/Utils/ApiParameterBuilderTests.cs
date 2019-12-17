using System;
using Confetti.MoySklad.Remap.Client;
using Confetti.MoySklad.Remap.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Confetti.MoySklad.Remap.IntegrationTests.Client
{
    internal class TestMetaEntity : MetaEntity
    {
        [JsonProperty("stringproperty")]
        public string StringProperty { get; set; }

        [JsonProperty("intproperty")]
        public int IntProperty { get; set; }

        [JsonProperty("datetimeproperty")]
        public DateTime DateTimeProperty { get; set; }

        [JsonProperty("booleanproperty")]
        public bool BooleanProperty { get; set; }

        [JsonProperty("nestedmetaentity")]
        public NestedMetaEntity NestedEntity { get; set; }

        public int? NullableIntPropertyWithoutJsonName { get; set; }

        public class NestedMetaEntity : MetaEntity
        {
            public NestedMetaEntity2 NestedEntity2 { get; set; }

            public class NestedMetaEntity2 : MetaEntity
            {
                
            }
        }
    }

    public class ApiParameterBuilderTests
    {
        private ApiParameterBuilder<TestMetaEntity> _subject;

        [SetUp]
        public void Init()
        {
            _subject = new ApiParameterBuilder<TestMetaEntity>();
        }

        [Test]
        public void Build_should_return_empty_dictionary()
        {
            _subject.Build().Should().BeEmpty();
        }

        [Test]
        public void Build_should_return_dictionary_with_filters_expanders_orders_and_search_parameters()
        {
            var d1 = DateTime.Now;
            var d2 = DateTime.Now.AddHours(1);
            _subject.Parameter(p => p.Name).Should().Be("test");
            _subject.Parameter(p => p.DateTimeProperty).Should().BeLessThan(d1, "yyyy-MM-dd_HH:mm:ss").And.BeGreaterOrEqualTo(d2, "yyyy-MM-dd_HH:mm:ss");
            _subject.Parameter(p => p.BooleanProperty).Should().Be(true);
            _subject.Parameter(p => p.IntProperty).Should().Be(5).Or.Be(10);
            _subject.Parameter(p => p.NullableIntPropertyWithoutJsonName).Should().BeNull();
            _subject.Parameter("customParameter").Should().BeGreaterThan("5");

            _subject.Expand().With(p => p.NestedEntity.NestedEntity2);

            _subject.Order().By(p => p.Name).And.By(p => p.IntProperty, OrderBy.Desc);

            _subject.Search("query");

            var result = _subject.Build();
            
            result.Should().HaveCount(4);
            result["filter"].Should().Be(
                $@"
                    name=test;
                    datetimeproperty<{d1.ToString("yyyy-MM-dd_HH:mm:ss")};
                    datetimeproperty>={d2.ToString("yyyy-MM-dd_HH:mm:ss")};
                    booleanproperty=true;
                    intproperty=5;
                    intproperty=10;
                    NullableIntPropertyWithoutJsonName=;
                    customParameter>5
                ".Replace("\n", "").Replace(" ", ""));
            result["expand"].Should().Be("nestedmetaentity.NestedEntity2");
            result["order"].Should().Be("name,asc;intproperty,desc");
            result["search"].Should().Be("query");
        }

        [Test]
        public void Parameter_should_throw_api_exception_if_nesting_property_level_is_more_than_one()
        {
            Action action = () => _subject.Parameter(p => p.NestedEntity.Name);
            action.Should().Throw<ApiException>();
        }
    }
}