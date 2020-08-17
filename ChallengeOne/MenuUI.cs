using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{
    public class MenuUI
    {
        private bool _isRunning = true;
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public void Start()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "Welcome to Komodo Cafe Management System!\n" +
                "Select Menu Item:\n" +
                "1. Show All Menu Items\n" +
                "2. Find Menu Item by Name\n" +
                "3. Add New Menu Item\n" +
                "4. Update Existing Menu Item\n" +
                "5. Remove Menu Item\n" +
                "6. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllContent();
                    break;
                case "2":
                    DisplayItemByName();
                    break;
                case "3":
                    CreateNewItem();
                    break;
                case "4":
                    UpdateMenuItem();
                    break;
                case "5":
                    RemoveMenuItemByName();
                    break;
                case "6":
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid input.");
                    return;
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private void DisplayAllContent()
        {
            List<Menu> listOfContent = _menuRepo.GetMenu();

            foreach (Menu content in listOfContent)
            {
                DisplayMenu(content);
            }
        }

        private void DisplayMenu(Menu content)
        {
            Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                $"Meal Name: {content.MealName}\n" +
                $"Description: {content.Description}\n" +
                $"Ingredients: {content.Ingredients}\n" +
                $"Price: ${content.Price}");
        }

        private void DisplayItemByName()
        {
            Console.WriteLine("Enter a Meal Name:");
            string mealName = Console.ReadLine();

            Menu searchResult = _menuRepo.GetMenuItemByName(mealName);

            if (searchResult != null)
            {
                DisplayMenu(searchResult);
            }
            else
            {
                Console.WriteLine("Invalid Meal Name. Could not find any results.");
            }
        }

        private void CreateNewItem()
        {
            // Meal Number
            Console.Write("Enter a Meal Number: ");
            int mealNumber = int.Parse(Console.ReadLine());

            // Meal Name 
            Console.Write("Enter a Meal Name: ");
            string mealName = Console.ReadLine();

            //Description
            Console.Write("Enter a Desscription: ");
            string description = Console.ReadLine();

            // Ingredients
            Console.Write("Enter the Ingredients: ");
            string ingredients = Console.ReadLine();

            // Price
            Console.Write("Enter a Price: $");
            decimal price = decimal.Parse(Console.ReadLine());

            Menu newContent = new Menu(mealNumber, mealName, description, ingredients, price);

            _menuRepo.AddContentToMenu(newContent);

            Console.WriteLine("Item has been added!");
        }

        private void UpdateMenuItem()
        {
            Console.WriteLine("Enter a Meal Name:");
            string mealInput = Console.ReadLine();

            _menuRepo.GetMenuItemByName(mealInput);

            // Meal Number
            Console.Write("Enter a Meal Number: ");
            int mealNumber = int.Parse(Console.ReadLine());

            // Meal Name 
            Console.Write("Enter a Meal Name: ");
            string mealName = Console.ReadLine();

            //Description
            Console.Write("Enter a Desscription: ");
            string description = Console.ReadLine();

            // Ingredients
            Console.Write("Enter the Ingredients: ");
            string ingredients = Console.ReadLine();

            // Price
            Console.Write("Enter a Price: $");
            decimal price = decimal.Parse(Console.ReadLine());

            Menu updatedContent = new Menu(mealNumber, mealName, description, ingredients, price);

            _menuRepo.UpdateExistingMenu(updatedContent, mealInput);

            Console.WriteLine("Item has been updated!");
        }

        private void RemoveMenuItemByName()
        {
            Console.Write("Enter a Meal Name: ");
            string mealName = Console.ReadLine();

            _menuRepo.DeleteContentByName(mealName);

            Console.WriteLine("Item has been deleted!");
        }

        private void SeedContentList()
        {
            Menu pizza = new Menu(1, "Pizza", "Whole pizza cut into squares", "Mozzarella, Pepperoni, Marinara Sauce, and Garlic Butter Crust", 15.99m);
            Menu burger = new Menu(2, "Cheeseburger", "Cheeseburger cooked to your choice of doneness", "Bun, 8 oz. Custom-Grind Patty, American Cheese, LTOP, Side of Fries", 12m);
            Menu chixWrap = new Menu(3, "Buffalo Chicken Wrap", "Spicy buffalo chicken wrap", "Flour wrap, Chicken, Buffalo Sauce, Cheddar Cheese, Ranch, Tomato, Lettuce", 10.99m);

            _menuRepo.AddContentToMenu(pizza);
            _menuRepo.AddContentToMenu(burger);
            _menuRepo.AddContentToMenu(chixWrap);
        }
    }
}
