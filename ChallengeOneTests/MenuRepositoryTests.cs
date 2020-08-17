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
        public void CreateMenuItem_ShouldReturnCorrect()
        {
            MenuRepository repo = new MenuRepository();
            Menu content = new Menu(4, "hot dog", "hot dog", "bun and wiener", 3.99m);

            repo.AddContentToMenu(content);

            Assert.AreEqual(content.MealName, "hot dog");
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            List<Menu> directory = _menuRepo.GetMenu();

            bool directoryHasMenu = directory.Contains(_menu);

            Assert.IsTrue(directoryHasMenu);
        }

        [TestMethod]
        public void GetItemByName_ShouldReturnCorrectItem()
        {
            Menu correctObject = _menuRepo.GetMenuItemByName("Pizza");

            Assert.AreEqual(correctObject.Price, 15.99m);
        }

        [DataTestMethod]
        [DataRow("pizza", true)]
        public void UpdateExistingItem_ShouldReturnTrue(string name, bool expectedResult)
        {
            bool updateItem = _menuRepo.UpdateExistingMenu(_menu, name);

            Assert.AreEqual(expectedResult, updateItem);
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
