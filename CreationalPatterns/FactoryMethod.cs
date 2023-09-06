using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    // The product participant
    public abstract class Ingredient
    {

    }

    // Concrete Product
    public class Bread : Ingredient { }
    public class CornedBeef: Ingredient { }
    public class Sauerkraut: Ingredient { }
    public class SwissCheese: Ingredient { }
    public class ThousandIslandsSauce: Ingredient { }

    public abstract class Sandwitch
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();
        public Sandwitch() {
            CreateIngrediants();
        }  
        public abstract void CreateIngrediants();
        public List<Ingredient> Ingredients { get { return _ingredients;} }
        public void DisplayIngrediants()
        {
            foreach(var ingrediant in  _ingredients)
            {
                Console.WriteLine(ingrediant.GetType().Name);
            }
        }
    }

    public class GrilledCheeseSandwitch : Sandwitch
    {
        public override void CreateIngrediants()
        {
            Ingredients.Add(new Bread());
            Ingredients.Add(new SwissCheese());
            Ingredients.Add(new Bread());
        }
    }

    public class ReubenSandwich : Sandwitch
    {
        public override void CreateIngrediants()
        {
            Ingredients.Add(new Bread());
            Ingredients.Add(new CornedBeef());
            Ingredients.Add(new Sauerkraut());
            Ingredients.Add(new SwissCheese());
            Ingredients.Add(new ThousandIslandsSauce());
            Ingredients.Add(new Bread());
        }
    }


}
