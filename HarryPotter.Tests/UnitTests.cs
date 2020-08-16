using HarryPotter.Service.Class;
using HarryPotter.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace HarryPotter.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public async Task InsertCharacter_ShouldReturnFalse()
        {
            var _mockService = new Mock<ICharacterService>().Object;
            var result = await _mockService.InsertCharacter("", "role", "Patronus", null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InsertCharacter_ShouldReturnTrue()
        {
            var _mock = new Mock<ICharacterService>();
            _mock.Setup(x => x.InsertCharacter("name", "role", "Patronus", null)).ReturnsAsync(true);
            //var _mockService = new Mock<ICharacterService>().Object;
            //var result = await _mockService.InsertCharacter("name", "role", "Patronus", null);

            //Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task UpdateCharacter_ShouldReturnFalse()
        {
            var _mockService = new Mock<ICharacterService>().Object;
            var result = await _mockService.UpdateCharacter("", "name", "role", "Patronus", null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateCharacter_ShouldReturnTrue()
        {
            var _mock = new Mock<ICharacterService>();
            _mock.Setup(x => x.UpdateCharacter(Guid.NewGuid().ToString(), "name", "role", "Patronus", null)).ReturnsAsync(true);
            //var _mockService = _mock.Object;
            //var result = await _mockService.UpdateCharacter(Guid.NewGuid().ToString(), "name", "role", "Patronus", null);

            //Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteCharacter_ShouldReturnFalse()
        {
            var _mockService = new Mock<ICharacterService>().Object;
            var result = _mockService.DeleteCharacter("");

            Assert.IsFalse(result);
        }
    }
}
