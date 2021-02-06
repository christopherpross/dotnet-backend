using Microsoft.AspNetCore.Mvc;
using Rest.Controllers;
using Xunit;

namespace Rest.Tests.IntegrationTests.ControllerTests
{
    /// <summary>
    /// !! TO BE REMOVED !!
    /// </summary>
    public sealed class DummyControllerTests
    {
        /// <summary>
        /// !! TO BE REMOVED !!
        /// </summary>
        private readonly DummyController _dummyController;
        
        /// <summary>
        /// !! TO BE REMOVED !!
        /// </summary>
        public DummyControllerTests()
        {
            _dummyController = new DummyController();
        }

        /// <summary>
        /// !! TO BE REMOVED !!
        /// </summary>
        [Fact]
        public void ReturnsOk()
        {
            IActionResult actionResult = _dummyController.Test();

            Assert.IsType<OkObjectResult>(actionResult);
        }
    }
}