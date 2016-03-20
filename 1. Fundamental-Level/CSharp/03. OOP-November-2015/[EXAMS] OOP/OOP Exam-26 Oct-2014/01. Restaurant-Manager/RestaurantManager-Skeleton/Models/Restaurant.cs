namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using RestaurantManager.Interfaces;

    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;

            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the restaurant cannot be empty.");
                }

                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The location of the restaurant cannot be empty.");
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes { get; private set; }

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format("***** {0} - {1} *****", this.Name, this.Location));

            if (this.Recipes.Count == 0)
            {
                output.Append("No recipes... yet");
                return output.ToString();
            }

            var sortedDrinks = this.Recipes
                .Where(recipe => recipe is IDrink)
                .OrderBy(drink => drink.Name);
            if (sortedDrinks.Any())
            {
                output.AppendLine("~~~~~ DRINKS ~~~~~");
                foreach (var drink in sortedDrinks)
                {
                    output.AppendLine(drink.ToString()).ToString().Trim();
                }
            }

            var sortedSalads = this.Recipes
                .Where(recipe => recipe is ISalad)
                .OrderBy(salad => salad.Name);
            if (sortedSalads.Any())
            {
                output.AppendLine("~~~~~ SALADS ~~~~~");
                foreach (var salad in sortedSalads)
                {
                    output.AppendLine(salad.ToString()).ToString().Trim();
                }
            }

            var sortedMainCourses = this.Recipes
               .Where(recipe => recipe is IMainCourse)
               .OrderBy(mainCourse => mainCourse.Name);
            if (sortedMainCourses.Any())
            {
                output.AppendLine("~~~~~ MAIN COURSES ~~~~~");
                foreach (var mainCourse in sortedMainCourses)
                {
                    output.AppendLine(mainCourse.ToString()).ToString().Trim();
                }
            }

            var sortedDesserts = this.Recipes
               .Where(recipe => recipe is IDessert)
               .OrderBy(dessert => dessert.Name);
            if (sortedDesserts.Any())
            {
                output.AppendLine("~~~~~ DESSERTS ~~~~~");
                foreach (var dessert in sortedDesserts)
                {
                    output.AppendLine(dessert.ToString()).ToString().Trim();
                }
            }

            return output.ToString().ToString().Trim();
        }
    }
}