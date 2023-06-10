using Assessment.Core.Models;
using FluentAssertions;
using System;
using System.Drawing;
using System.Threading.Tasks;
using Xunit;

namespace Assesment.Core.Tests.Models
{
    public class ItemTests
    {
        [Theory]
        [InlineData("{}", @"{""name"":null,""imageUri"":null,""color"":null,""Id"":""00000000000000000000000000"",""CreatedDate"":null,""LastUpdated"":null,""InactiveDate"":null,""IsActive"":true}")]
        [InlineData(@"{""name"":null,""imageUri"":null, ""color"":null}", @"{""name"":null,""imageUri"":null,""color"":null,""Id"":""00000000000000000000000000"",""CreatedDate"":null,""LastUpdated"":null,""InactiveDate"":null,""IsActive"":true}")]
        [InlineData(@"{""name"":""theName"",""imageUri"":""file://./images/image001.jpg"", ""color"":""Red""}", @"{""name"":""theName"",""imageUri"":""file://./images/image001.jpg"",""color"":""Red"",""Id"":""00000000000000000000000000"",""CreatedDate"":null,""LastUpdated"":null,""InactiveDate"":null,""IsActive"":true}")]
        public async Task ParseAsync_WithValidJson_ShouldProduceExpectedObject(string json, string expectedJson)
        {
            // Arrange
            // done as theory

            // Act
            var result = await Item.ParseAsync(
                json);

            // Assert
            result.ToString().Should().Be(expectedJson);
            result.IsTransient.Should().BeTrue();
            result.IsActive.Should().BeTrue();
            result.MarkModified.Should().BeFalse();
        }

        [Fact]
        public void CompareTo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var item = new Item
            {
                Color = Color.Blue,
                Name = "blueImage",
                ImageUri = "file://./images/blueimage.png"
            };
            var other = new Item
            {
                Color = Color.Red,
                Name = "other",
                ImageUri = @"file://.\images\redimage.png"
            };

            // Act/Assert
            item.CompareTo(other).Should().BeLessThan(0);
            other.CompareTo(item).Should().BeGreaterThan(0);
            other.CompareTo(null).Should().Be(-1);
        }

        [Fact]
        public void EqualByFields_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var item = new Item
            {
                Color = Color.Blue,
                Name = "blueImage",
                ImageUri = "file://./images/blueimage.png"
            };
            var other = new Item
            {
                Color = Color.Red,
                Name = "other",
                ImageUri = @"file://.\images\redimage.png"
            };
            var persisted = new Item
            {
                Id = Ulid.NewUlid(),
                Color = Color.Blue,
                CreatedDate = DateTimeOffset.Now,
                ImageUri = "file://./images/blueimage.png",
                Name = "blueImage"
            };
            // Act/Assert
            item.EqualByFields(other).Should().BeFalse();
            item.EqualByFields(item).Should().BeTrue();
            (item == other).Should().BeFalse();
            (item != other).Should().BeTrue();
#pragma warning disable CS1718 // Comparison made to same variable
            (item == item).Should().BeTrue();
#pragma warning restore CS1718 // Comparison made to same variable
            (item == null).Should().BeFalse();
            item.Equals(persisted).Should().BeTrue();
            (item == persisted).Should().BeTrue();
        }
    }
}
