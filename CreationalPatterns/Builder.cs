﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    // “Separate the construction of a complex object from its representation so that the same
    // construction process can create different representations”

    // It is used to construct a complex object step by step and the final step returns the object.
    // Also, the process of constructing an object should be generic so that it can be used to create
    // different representations of the same object.

    //Builder - This is an interface which is used to define all the steps required to create a product.
    //ConcreteBuilder - This is a class which implements the Builder interface to create a complex product.
    //Product - This is a class which defines the parts of the complex object which are to be generated by the Builder Pattern.
    //Director - This is a class that is used to construct an object using the Builder interface.


    // IToyBuilder Interface which will be used by Concrete builder Classes 

    public interface IToyBuilder {
        void SetModel();
        void SetHead();
        void SetLimbs();
        void SetBody();
        void SetLegs();
        Toy GetToy();
    }

    // Concrete Classes for creating Two Types of Toys
    public class ToyABuilder : IToyBuilder
    {
        Toy toy = new Toy();
        public Toy GetToy()
        {
            return toy;   
        }

        public void SetBody()
        {
            toy.Body = "Plastic";
        }

        public void SetHead()
        {
            toy.Head = "1";
        }

        public void SetLegs()
        {
             toy.Legs = "1";
        }

        public void SetLimbs()
        {
            toy.Limbs = "4";
        }

        public void SetModel()
        {
            toy.Model = "Toy A";
        }
    }

    public class ToyBBuilder : IToyBuilder
    {
        Toy toy = new Toy();
        public Toy GetToy()
        {
            return toy;
        }

        public void SetBody()
        {
            toy.Body = "Steel";
        }

        public void SetHead()
        {
            toy.Head = "1";
        }

        public void SetLegs()
        {
            toy.Legs = "4";
        }

        public void SetLimbs()
        {
            toy.Limbs = "4";
        }

        public void SetModel()
        {
            toy.Model = "Toy B";
        }
    }

    // Director Class which will be responsible for construction of an Object using Builder Interface
    public class ToyCreator
    {
        public IToyBuilder? _toyBuilder;
        public ToyCreator(IToyBuilder? toyBuilder)
        {
            _toyBuilder = toyBuilder;
        }
        public void CreateToy()
        {
            _toyBuilder.SetModel();
            _toyBuilder.SetHead();
            _toyBuilder.SetLimbs();
            _toyBuilder.SetLegs();
            _toyBuilder.SetBody();
        }
        public Toy GetToy()
        {
            return _toyBuilder.GetToy();
        }

    }

    // Product Class for Toy

    public class Toy
    {
        public string? Model { get; set; }
        public string? Head { get; set; }
        public string? Limbs { get; set;}
        public string? Body { get; set; }
        public string? Legs { get; set; }

    }

}
