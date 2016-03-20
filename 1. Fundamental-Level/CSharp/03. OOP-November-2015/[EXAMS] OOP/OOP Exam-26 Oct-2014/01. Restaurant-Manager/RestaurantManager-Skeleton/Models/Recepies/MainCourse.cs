namespace RestaurantManager.Models.Recepies
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.IsVegan = isVegan;
            this.Type = (MainCourseType)Enum.Parse(typeof(MainCourseType), type);
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            string veganLabel = this.IsVegan ? "[VEGAN] " : "";

            return veganLabel +
                base.ToString() +
                string.Format("\nType: {0}", this.Type);
        }
    }
}