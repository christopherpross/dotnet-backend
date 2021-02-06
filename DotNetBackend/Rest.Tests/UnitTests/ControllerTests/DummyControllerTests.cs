using Microsoft.AspNetCore.Mvc;
using Rest.Controllers;
using Xunit;

namespace Rest.Tests.UnitTests.ControllerTests
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
        public void ReturnsWorks()
        {
            IActionResult actionResult = _dummyController.Test();
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            
            Assert.True(okObjectResult.Value.Equals("Works"));
        }
    }
}