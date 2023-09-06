using CreationalPatterns;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace DesignPatternPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void abstractfactory1()
            {
                #region Abstract Factory
                int style, furniture;
                do
                {
                    Console.WriteLine(" Please select your Furniture Style");
                    Console.WriteLine(" [1]Classic [2]Contemporary [3]Scandinavian");
                    int.TryParse(Console.ReadLine(), out style);
                }
                while (style == 0 || style > 3);
                IFurnitureFactory? factory = null;
                switch (style)
                {
                    case 1:
                        factory = new ClassicFurnitureFactory();
                        break;
                    case 2:
                        factory = new ContemporaryFurnitureFactory();
                        break;
                    case 3:
                        factory = new ScandinavianFurnitureFactory();
                        break;
                }
                do
                {
                    Console.WriteLine("Please select your Furniture");
                    Console.WriteLine("[1]Cabinet [2]Chair [3]Dining Table");
                    int.TryParse(Console.ReadLine(), out furniture);
                }
                while (furniture == 0 || furniture > 3);
                IFurniture? furnitureProduct = null;
                switch (furniture)
                {
                    case 1:
                        furnitureProduct = factory.CreateCabinet();
                        break;
                    case 2:
                        furnitureProduct = factory.CreateChair();
                        break;
                    case 3:
                        furnitureProduct = factory.CreateDiningTable();
                        break;

                }

                Console.WriteLine("Furniture Created");
                furnitureProduct.showFurnitureFunction();
                furnitureProduct.showFurnitureStyle();
                #endregion
            }

            static void abstractfactory2()
            {
                ApplicationProduct app = ConfigureApplication();
                app.Paint();

                static ApplicationProduct ConfigureApplication()
                {
                    if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        return new ApplicationProduct(new WindowsFactory());
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        return new ApplicationProduct(new  LinuxFactory());
                    }
                    else return new ApplicationProduct(new MacOSFactory());
                }

            }

            static void builderPattern1()
            {
                #region Builder Pattern Example 1
                Console.WriteLine("List of Toys: ");
                var toyACreator = new ToyCreator(new ToyABuilder());
                toyACreator.CreateToy();
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(toyACreator.GetToy()));
                var toyBCreator = new ToyCreator(new ToyBBuilder());
                toyBCreator.CreateToy();
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(toyBCreator.GetToy()));
                #endregion
            }


            static void builderPattern2()
            {
                #region Builder Pattern Example 2
                // The client code in Builder Design Pattern is going to create a builder object,
                // then pass that builder object to the director and then the director will initiate
                // the construction process.The end result is nothing the product is retrieved from
                // the builder object.

                // Constructing the PDF Report
                // Step 1 : Create the Builder Object
                PDFReport pdfReport = new PDFReport();

                // Step 2: Pass the Builder Object to the instance of Director
                ReportDirector reportDirector = new ReportDirector();
                Report report = reportDirector.MakeReport(pdfReport);
                report.DisplayReport();

                // Constructing the Excel Report
                // Process is going to be same
                ExcelReport excelReport = new ExcelReport();
                report = reportDirector.MakeReport(excelReport);
                report.DisplayReport();

                #endregion
            }

            static void factorymethod()
            {
                Console.WriteLine("Reuben Sandwitch");
                ReubenSandwich reubenSandwich = new ReubenSandwich();
                reubenSandwich.DisplayIngrediants();
                Console.WriteLine("\n------------------------\n");
                Console.WriteLine("Grilled Cheese Sandwitch");
                GrilledCheeseSandwitch grilledCheeseSandwitch = new GrilledCheeseSandwitch();
                grilledCheeseSandwitch.DisplayIngrediants();
            }

            static void prototypeShallowCopy()
            {
                Console.WriteLine("Shallow Copy Sample");
                AuthorForShallowCopy authorForShallowCopy = new AuthorForShallowCopy()
                {
                    Name = "Abhishek P",
                    TwitterAccount = "http://twitter.com/abhp",
                    Website = "abhishekprasad.com",
                    HomeAddress = new AddressType1
                    {
                        City = "Mumbai",
                        State = "Maharastra"
                    }
                };

                Console.WriteLine("Original Copy: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(authorForShallowCopy));
                AuthorForShallowCopy clonedObject = (AuthorForShallowCopy)authorForShallowCopy.Clone();
                Console.WriteLine("Cloned Copy: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(clonedObject));
                Console.WriteLine("Making Changes to cloned copy: ");
                clonedObject.Name = "Dheeraj Kumar";
                clonedObject.Website = "dheerajkumar.com";
                clonedObject.TwitterAccount = "http://twitter.com/dhk";
                clonedObject.HomeAddress.State = "Karnataka";
                clonedObject.HomeAddress.City = "Bengaluru";
                Console.WriteLine("Cloned Object: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(clonedObject));
                Console.WriteLine("Original Copy: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(authorForShallowCopy));
            }

            static void prototypeDeepCopy()
            {
                Console.WriteLine("Deep Copy Sample");
                AuthorForDeepCopy authorForDeepCopy = new AuthorForDeepCopy()
                {
                    Name = "Abhishek P",
                    TwitterAccount = "http://twitter.com/abhp",
                    Website = "abhishekprasad.com",
                    HomeAddress = new AddressType2
                    {
                        City = "Mumbai",
                        State = "Maharastra"
                    }
                };

                Console.WriteLine("Original Copy: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(authorForDeepCopy));
                AuthorForDeepCopy clonedObject = (AuthorForDeepCopy)authorForDeepCopy.Clone();
                Console.WriteLine("Cloned Copy: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(clonedObject));
                Console.WriteLine("Making Changes to cloned copy: ");
                clonedObject.Name = "Dheeraj Kumar";
                clonedObject.Website = "dheerajkumar.com";
                clonedObject.TwitterAccount = "http://twitter.com/dhk";
                clonedObject.HomeAddress.State = "Karnataka";
                clonedObject.HomeAddress.City = "Bengaluru";
                Console.WriteLine("Cloned Object: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(clonedObject));
                Console.WriteLine("Original Copy: ");
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(authorForDeepCopy));
            }

            //abstractfactory1();
            //abstractfactory2();
            //builderPattern1();
            //builderPattern2();
            // factorymethod();
            //prototypeShallowCopy();
            prototypeDeepCopy();

        }

    }
}