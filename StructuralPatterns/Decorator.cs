using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    // The Decorator Pattern provides a flexible alternative to sub classing for extending functionality dynamically.

    // The idea of the Decorator Pattern is to wrap an existing class, add other functionality to it, then expose
    // the same interface to the outside world.Because of this our decorator exactly looks like the original class
    // to the people who are using it.
    // It is used to extend or alter the functionality at runtime. It does this by wrapping them in an object of the
    // decorator class without modifying the original object. So it can be called a wrapper pattern.

    // Component: It defines the interface of the actual object that needs functionality to be added dynamically to the ConcreteComponents.
    // ConcreteComponent: The actual object in which the functionalities could be added dynamically.
    // Decorator: This defines the interface for all the dynamic functionalities that can be added to the ConcreteComponent.
    // ConcreteDecorator: All the functionalities that can be added to the ConcreteComponent.Each needed functionality will
    // be one ConcreteDecorator class.

    // Car base Component
    public interface ICar
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Car
    public class EconomyCar: ICar
    {
        public string GetDescription()
        {
            return "Economy Car";
        }

        public double GetCost()
        {
            return 450000;
        }
    }

    // Concrete Car
    public class DeluxeCar : ICar
    {
        public double GetCost()
        {
            return 750000;
        }

        public string GetDescription()
        {
            return "Deluxe Car";
        }
    }

    // Concrete Car
    public class LuxuryCar : ICar
    {
        public double GetCost()
        {
            return 950000;
        }

        public string GetDescription()
        {
            return "Luxury Car";
        }
    }

    // Concrete Car
    public class SuperLuxury : ICar
    {
        public double GetCost()
        {
            return 1250000;
        }

        public string GetDescription()
        {
            return "Super Luxury Car";
        }
    }

    // Abstract Decorator
    public abstract class CarAccessoriesDecorator : ICar
    {
        private ICar _car;
        public CarAccessoriesDecorator(ICar car)
        {
            this._car = car;
        }

        public virtual double GetCost()
        {
            return this._car.GetCost();
        }

        public virtual string GetDescription()
        {
            return this._car.GetDescription();
        }
    }

    // Concrete Decorator
    public class BasicAccessories : CarAccessoriesDecorator
    {
        public BasicAccessories(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return base.GetCost() + 2000;    
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Basic Accessories Package ";
        }
    }

    // Concrete Decorator
    public class AdvancedAccessories : CarAccessoriesDecorator
    {
        public AdvancedAccessories(ICar car) : base(car)
        {
        }
        public override double GetCost() 
        {
            return base.GetCost() + 8000;
        }
        public override string GetDescription() 
        {
            return base.GetDescription() + ", Advanced Accessories Package";
        }
    }

    // Concrete Decorator
    public class SportsAccessories : CarAccessoriesDecorator
    {
        public SportsAccessories(ICar car) : base(car)
        {
        }

        public override double GetCost()
        {
            return base.GetCost() + 15000;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Sports Accessories Package";   
        }
    }

    public class ExtremeSportAccessories : CarAccessoriesDecorator
    {
        public ExtremeSportAccessories(ICar car) : base(car)
        {
        }
        public override double GetCost()
        {
            return base.GetCost() + 25000;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Extreme Sports Accessories Package";
        }
    }


}
