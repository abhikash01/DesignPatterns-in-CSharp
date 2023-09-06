using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{
    /// <summary>
    /// The Abstract Factory pattern assumes that we have several families
    /// of products, structured into separate class hierarchies (Button/Checkbox/Panel).
    /// All products of the same family have a common interface. 
    /// 
    /// This is the common interface for buttons family.
    /// </summary>
    public interface IButton
    {
        public void Paint();
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows).
    /// 
    /// This is a Linux variant of a button.
    /// </summary>
    public class LinuxButton: IButton
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Linux Button");
        }
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows).
    /// 
    /// This is a Windows variant of a button.
    /// </summary>
    public class WindowsButton: IButton
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Windows Button");
        }
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows).
    /// 
    /// This is a MacOS variant of a button.
    /// </summary>
    public class MacOSButton: IButton
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created MacOS Button");
        }
    }

    /// <summary>
    /// Checkboxes are the second product family.
    /// It has the same variants as buttons.
    /// </summary>
    public interface ICheckbox
    {
        public void Paint();
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows)
    /// 
    /// This is a variant of a checkbox.
    /// </summary>
    public class LinuxCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Linux Checkbox");
        }
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows)
    /// 
    /// This is a variant of a checkbox.
    /// </summary>
    public class WindowsCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Windows Checkbox");
        }
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows)
    /// 
    /// This is a variant of a checkbox.
    /// </summary>
    public class MacOSCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Mac OS Checkbox");
        }
    }

    /// <summary>
    /// Panels is the third product family. It has the same variants as buttons and checkboxes.
    /// </summary>
    public interface IPanel
    {
        public void Paint();
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows)
    /// 
    /// This is a variant of a panel.
    /// </summary>
    public class LinuxPanel : IPanel
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Linux Panel");
        }
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows)
    /// 
    /// This is a variant of a panel.
    /// </summary>
    public class WindowsPanel : IPanel
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Windows Panel");
        }
    }

    /// <summary>
    /// All product families have the same varieties (Linux/MacOS/Windows)
    /// 
    /// This is a variant of a panel.
    /// </summary>
    public class MacOsPanel : IPanel
    {
        public void Paint()
        {
            Console.WriteLine("Successfully created Mac OS Panel");
        }
    }

    /// <summary>
    /// Abstract factory knows about all (abstract) product types
    /// </summary>
    public interface IGUIFactory
    {
        public IButton CreateButton();
        public ICheckbox CreateCheckbox();
        public IPanel CreatePanel();

    }

    /// <summary>
    /// Factory users don't care which concrete factory they use since they work with
    /// factories and products through abstract interfaces.
    /// </summary>
    public class Application
    {
        private ICheckbox checkbox;
        private IButton button;
        private IPanel panel;
    }

    /// <summary>
    /// Each concrete factory extends basic factory and responsible for creating 
    /// products of a single variety
    /// </summary>
    public class LinuxFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new LinuxButton();

        }

        public ICheckbox CreateCheckbox()
        {
            return new LinuxCheckbox();
        }

        public IPanel CreatePanel()
        {
            return new LinuxPanel();
        }
    }

    /// <summary>
    /// Each concrete factory extends basic factory and responsible for creating 
    /// products of a single variety.
    /// </summary>
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }

        public IPanel CreatePanel()
        {
            return new WindowsPanel();
        }
    }

    /// <summary>
    /// Each concrete factory extends basic factory and responsible for creating 
    /// products of a single variety.
    /// </summary>
    public class MacOSFactory : IGUIFactory
    {
        IButton IGUIFactory.CreateButton()
        {
            return new MacOSButton();   
        }

        ICheckbox IGUIFactory.CreateCheckbox()
        {
            return new MacOSCheckbox();
        }

        IPanel IGUIFactory.CreatePanel()
        {
            return new MacOsPanel();
        }
    }

    /// <summary>
    /// Factory users don't care which concrete factory they use since they work with
    /// factories and products through abstract interfaces.
    /// </summary>
    public class ApplicationProduct
    {
        private IButton button;
        private IPanel panel;
        private ICheckbox checkbox;

        public ApplicationProduct(IGUIFactory factory)
        {
            button = factory.CreateButton();
            panel = factory.CreatePanel();
            checkbox =  factory.CreateCheckbox();
        }

        public void Paint()
        {
            button.Paint();
            panel.Paint();
            checkbox.Paint();
        }
    }



}
