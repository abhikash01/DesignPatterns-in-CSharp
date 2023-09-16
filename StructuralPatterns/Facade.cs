using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    // Facade is a structural design pattern that provides a simplified interface
    // to a library, a framework, or any other complex set of classes.

    // If we try to understand this in simpler terms, then we can say that a room is a
    // façade and just by looking at it from outside the door, one can not predict what
    // is inside the room and how the room is structured from inside. Thus, Façade is a
    // general term for simplifying the outward appearance of a complex or large system.

    // This pattern involves one wrapper class which contains a set of methods available
    // for the client. This pattern is particularly used when a system is very complex or
    // difficult to understand and when the system has multiple subsystems.

    // For example, When someone calls the restaurant, suppose, for ordering pizza or some
    // other food, then the operator on behalf of the restaurant gives the voice interface
    // which is actually the façade for their customers.

    // Customers place their orders just by talking to the operator and they don’t need to
    // bother about how they will prepare the pizza, what all operations will they perform,
    // on what temperature they will cook, etc.


    // Interface specific to Pizza
    public interface IPizza
    {
        void GetVegPizza();
        void GetNonVegPizza();
    }

    // Pizza provider class which will get Pizza for the Clients
    public class PizzaProvider : IPizza
    {
        public void GetNonVegPizza()
        {
            Console.WriteLine("Getting Non Veg Pizza");
        }

        public void GetVegPizza()
        {
            Console.WriteLine("Getting Veg Pizza");
        }

        private void GetNonVegToppings()
        {
            Console.WriteLine("Getting Non Veg Pizza Toppings");
        }
    }

    // Interface specific to Breads
    public interface IBread
    {
        void GetGarlicBread();
        void GetCheesyGarlicBread();
    }


    // Bread Provider Class
    public class BreadProvider : IBread
    {
        public void GetCheesyGarlicBread()
        {
            Console.WriteLine("Getting Cheesy Garlic Bread");
        }

        public void GetGarlicBread()
        {
            Console.WriteLine("Getting Garlic Bread");
        }

        private void GetCheese()
        {
            Console.WriteLine("Getting Cheese");
        }
    }

    // The restaurant façade class, which will be used by the client to order different pizzas or breads.
    public class RestaurantFacade
    {
        private IPizza _PizzaProvider;
        private IBread _BreadProvider;

        public RestaurantFacade()
        {
            _PizzaProvider = new PizzaProvider();
            _BreadProvider = new BreadProvider();
        }

        public void GetNonVegPizza()
        {
            _PizzaProvider.GetNonVegPizza();
        }

        public void GetVegPizza()
        {
            _PizzaProvider.GetVegPizza();
        }

        public void GetGarlicBread()
        {
            _BreadProvider.GetGarlicBread();
        }

        public void GetCheesyGarlicBread()
        {
            _BreadProvider.GetCheesyGarlicBread();
        }
    }
}
