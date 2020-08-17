using System;
using System.Collections.Generic;
using ChallengeOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneTests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _menuRepo;
        private Menu _menu; 

        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepository();
            _menu = new Menu(1, "Pizza", "Whole pizza cut into squares", "Mozzarella, Pepperoni, Marinara Sauce, and Garlic Butter Crust", 15.99m);

            _menuRepo.AddContentToMenu(_menu);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            List<Menu> directory = _menuRepo.GetMenu();

            bool directoryHasMenu = directory.Contains(_menu);

            Assert.IsTrue(directoryHasMenu);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            bool removeResult = _menuRepo.DeleteExistingMenuItem(_menu);

            Assert.IsTrue(removeResult);
        }

        [DataTestMethod]
        [DataRow("pizza", true)]
        [DataRow("hot dog", false)]
        public void DeleteByName_ShouldReturnCorrectBool(string name, bool expectedResult)
        {
            bool actualResult = _menuRepo.DeleteContentByName(name);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
