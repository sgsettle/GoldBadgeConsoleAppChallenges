using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    public class MenuRepository
    {
        private List<Menu> _menuDirectory = new List<Menu>();

        // CREATE
        public void AddContentToMenu(Menu content)
        {
            _menuDirectory.Add(content);
        }

        // READ
        public List<Menu> GetMenu()
        {
            return _menuDirectory;
        }

        public Menu GetMenuItemByName(string mealName)
        {
            foreach (Menu item in _menuDirectory)
            {
                if (item.MealName.ToLower() == mealName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }

        // UPDATE
        public bool UpdateExistingMenu(Menu updatedContent, string originalName)
        {
            Menu content = GetMenuItemByName(originalName);
            if (content != null)
            {
                int itemIndex = _menuDirectory.IndexOf(content);
                _menuDirectory[itemIndex] = updatedContent;
                return true;
            }

            return false;
        }

        // DELETE
        public bool DeleteExistingMenuItem(Menu content)
        {
            return _menuDirectory.Remove(content);
        }

    }
}
