using Assessment.Core.Services;
using System.Threading.Tasks;
using Xunit;

namespace Assessment.Core.Tests
{
    // TODO: Add appropriate unit tests.
    public class Tests
    {
        [Fact]
        public void Test1()
        {
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsImageGalleryDataAsync()
        {
            var actual = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            Assert.NotEmpty(actual);
        }

        // Remove or update this once your app is using real data and not the SampleDataService.
        // This test serves only as a demonstration of testing functionality in the Core library.
        [Fact]
        public async Task EnsureSampleDataServiceReturnsListDetailsDataAsync()
        {
            var actual = await SampleDataService.GetListDetailsDataAsync();

            Assert.NotEmpty(actual);
        }
    }
}
