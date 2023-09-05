using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract Factory patterns act a super-factory which creates other factories. 
// This pattern is also called a Factory of factories. 
// In Abstract Factory pattern an interface is responsible for creating a set/families of related objects,
// or dependent objects without specifying their concrete classes.

// Product - This is an interface for creating the objects.
// ConcreteProduct  - This is a class which implements the Product interface.
// Creator - This is an abstract class and declares the factory method, which returns an object of type Product.
// ConcreteCreator - This is a class which implements the Creator class and overrides the factory method to return an instance of a ConcreteProduct.


// The furniture is categorized by design, which are Classic, Contemporary, and Scandinavian.
// The furniture itself has 3 different objects, which are Cabinet, Chair and Dining Table,
// so there will be 9 different combinations

namespace CreationalPatterns
{
   // Since all Furniture share a common method, create an interface to be implemented by all Furniture Classes
    public interface IFurniture
    {
        void showFurnitureFunction();
        void showFurnitureStyle();
    }

    // Each product has it's own Class with it's own Customized Message 
    public class ClassicCabinet : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("I'm used for storing Items.");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Classic Cabinet.");
        }
    }

    public class ClassicChair : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("People enjoy eating Food sitting on me.");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Classic Chair.");
        }
    }

    public class ClassicDiningTable : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("People keep their Stuff on me");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Classic Table");
        }
    }

    public class ScandinavianCabinet : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("I'm used for storing Items.");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Scandinavian Cabinet.");
        }
    }

    public class ScandinavianChair : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("People enjoy eating Food sitting on me.");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Scandinavian Chair.");
        }
    }

    public class ScandinavianDiningTable : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("People keep their Stuff on me");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Scandinavian Table");
        }
    }

    public class ContemporaryCabinet : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("I'm used for storing Items.");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Contemporary Cabinet.");
        }
    }

    public class ContemporaryChair : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("People enjoy eating Food sitting on me.");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Contemporary Chair.");
        }
    }

    public class ContemporaryDiningTable : IFurniture
    {
        public void showFurnitureFunction()
        {
            Console.WriteLine("People keep their Stuff on me");
        }

        public void showFurnitureStyle()
        {
            Console.WriteLine("I am a Contemporary Table");
        }
    }


    // Since the Furniture Factory needs to produce a Cabinet, Chair & Dining Table, create an interface
    // called IFurnitureFactory that will be implemented by different Design Factory

    public interface IFurnitureFactory
    {
        IFurniture CreateCabinet();
        IFurniture CreateChair();
        IFurniture CreateDiningTable();
    }


    // Concrete Factory/Class that create the Real Objects. Each Concrete Factory creates own Category Factory
    // ClassicFurnitureFactory creates all Classic Furnitures
    public class ClassicFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ClassicCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ClassicChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ClassicDiningTable();
        }
    }

    // ScandinavianFurnitureFactory creates all Scandinavian furniture.
    public class ScandinavianFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ScandinavianCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ScandinavianChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ScandinavianDiningTable();
        }
    }

    public class ContemporaryFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ContemporaryCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ContemporaryChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ContemporaryDiningTable();
        }
    }






}
