using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    // The Adapter design pattern converts the interface of a class into another interface clients expect.
    // This design pattern lets classes work together that couldn‘t otherwise because of incompatible interfaces.

    // The classes and objects participating in this pattern include:

    // Target   (ChemicalCompound) - defines the domain-specific interface that Client uses.
    // Adapter(Compound) - adapts the interface Adaptee to the Target interface.
    // Adaptee(ChemicalDatabank) - defines an existing interface that needs adapting.
    // Client(AdapterApp) - collaborates with objects conforming to the Target interface.

    // This real-world code demonstrates the use of a legacy chemical databank.
    // Chemical compound objects access the databank through an Adapter interface.

    // The Target Class
    public class Compound
    {
        protected float boilingPoint;
        protected float meltingPoint;
        protected double molecularWeight;
        protected string? molecularFormula;

        public virtual void Display()
        {
            Console.WriteLine("\nCompound Unknown");
        }
    }

    // The Adapter Class
    public class RichCompund: Compound
    {
        private string chemical;
        private ChemicalDataBank bank;

        public RichCompund(string chemical)
        {
            this.chemical = chemical;
        }

        public override void Display()
        {
            bank = new ChemicalDataBank();

            boilingPoint = bank.GetCriticalPoint(chemical, "B");
            meltingPoint = bank.GetCriticalPoint(chemical, "M");
            molecularWeight = bank.GetMolecularWeight(chemical);
            molecularFormula = bank.GetMolecularStructure(chemical);

            Console.WriteLine("\n Compund: {0}", chemical);
            Console.WriteLine("\n Formula: {0}", molecularFormula);
            Console.WriteLine("\n Weight: {0}", molecularWeight);
            Console.WriteLine("\n Boiling Point: {0}", boilingPoint);
            Console.WriteLine("\n Melting Point: {0}", meltingPoint);

        }
    }

    // The Adaptee Class
    public class ChemicalDataBank
    {
        // Databank Legacy API
        public float GetCriticalPoint(string compound, string point)
        {
            // Melting Point
            if(point == "M")
            {
                switch(compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "ethanol": return -114.1f;
                    default: return 0f;
                }
            }
            else
            {
                switch(compound.ToLower())
                {
                    case "water": return 100.0f;
                    case "benzene": return 80.1f;
                    case "ethanol": return 78.3f;
                    default: return 0f;
                }
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                default: return "";
            }
        }

        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToLower())
            {
                case "water": return 18.015;
                case "benzene": return 78.1134;
                case "ethanol": return 46.0688;
                default: return 0d;
            }
        }
    }





}
