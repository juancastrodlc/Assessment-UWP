using Assessment.ViewModels;

using Xunit;

namespace Assessment.Tests
{
    // TODO: Add appropriate tests
    public class Tests
    {
        [Fact]
        public void TestMethod1()
        {
        }

        // TODO: Add tests for functionality you add to ImageGalleryViewModel.
        [Fact]
        public void TestImageGalleryViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new ImageGalleryViewModel();
            Assert.NotNull(vm);
        }

        // TODO: Add tests for functionality you add to ListDetailsViewModel.
        [Fact]
        public void TestListDetailsViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new ListDetailsViewModel();
            Assert.NotNull(vm);
        }

        // TODO: Add tests for functionality you add to MainViewModel.
        [Fact]
        public void TestMainViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new MainViewModel();
            Assert.NotNull(vm);
        }
    }
}
