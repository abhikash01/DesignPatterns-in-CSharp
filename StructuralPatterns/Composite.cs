using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    //  Composite is a tree structure consisting of individual objects mixed with compositions
    //  of objects, that is, objects that have other objects as their children. The goal of the
    //  Composite pattern is to be able to treat individual objects and compositions of objects
    //  the same way. All objects in the Composite are derived from Composite itself. 

    // "Compose objects into tree structures to represent whole-part hierarchies. Composite lets
    // clients treat individual objects and compositions of objects uniformly." 

    // Key to a composite pattern is an abstract class that represents both primitives(individual objects)
    // and their containers(compositions of objects). Define an abstract base class (Component) that specifies
    // the behavior that needs to be exercised uniformly across all primitive and composite objects.

    // Single Interface for Primitives & Composite Types
    public abstract class Component
    {
        abstract public void AddChild(Component c);
        abstract public void Traverse();
    }

    // A Primitive Type
    public class Leaf : Component
    {
        private int value = 0;
        public Leaf(int value)
        {
            this.value = value;
        }

        public override void AddChild(Component c)
        {
            // No action. This method is not needed for Leaf;
        }

        public override void Traverse()
        {
            Console.WriteLine("Leaf: " + value);
        }
    }

    // Composite Type
    public class Composite : Component
    {
        private int value = 0;
        private ArrayList ComponentList = new ArrayList();
        public Composite(int value)
        {
            this.value = value;
        }

        public override void AddChild(Component c)
        {
            ComponentList.Add(c); 
        }

        public override void Traverse()
        {
            Console.WriteLine("Composite: " + value);
            foreach(Component c in ComponentList)
            {
                c.Traverse();
            }
        }
    }

}
