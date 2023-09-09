using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Buffers.Text;

namespace StructuralPatterns
{
    // It acts as an intermediary between two components.
    // The Adapter Pattern is designed to act as an intermediary when the two components are not
    // compatible to work with each other.Also the Adapter Pattern can add more functionality to a
    // source component request, before passing it on to the target component, with which the source
    // component is to interact.

    // On the other hand, the Bridge Pattern's purpose is to provide multiple
    // pathways between two components that are nothing but achieving many to many communication between
    // multiple implementations of the source and the target components.
    //According to the GoF's definition, this pattern "separates an object's interface from its implementation".

    // As per the preceding definition, it helps us to create a structure, where even the interface is separated
    // from the implementation using a bridge. Technically this results in a system where a function can have multiple
    // implementations and each implementation of that function can be used in multiple ways. So this results in a system
    // with many-to-many mappings. 

    // Abstraction - This will be the abstract class that will have the abstract logic to be implemented.
    // Most importantly, this will hold a reference to the bridge (that will internally have a reference
    // to the system through which notification is to be sent). The rest is just like any other
    // interface-based definition of the functions to be implemented.

    // Abstraction Details -These will be concrete implementations of the abstraction of Step 1.

    // Bridge Abstraction - This is the abstract component that will act as a bridge between the two components.

    // Bridge Implementations -These are the implementations for the bridge and will provide various ways in which
    // we can call the required logic implementations of Step 2.

    // Abstract Bridge Component
    public interface IBridgeComponent
    {
        void Send(string messageType);
    }

    // Abstract Logic Class with reference to the Bridge
    public abstract class SendData
    {
        // Reference to the Bridge
        public  IBridgeComponent _iBridgeComponent;

        public abstract void Send();
    }

    public class SendEmail : SendData
    {
        public override void Send()
        {
            // Use the Bridge to send the email
            _iBridgeComponent.Send("Email");
        }
    }

    public class SendSMS: SendData
    {
        public override void Send()
        {
            // Use the Bridge to send the SMS
            _iBridgeComponent.Send("SMS");
        }
    }

    // Next we will be have multiple implementations of the bridge, that is nothing but different ways in which
    // we can send these user notifications. So this is nothing but another implementation of the interface, but
    // this time its the Bridge interface.

    public class WebService : IBridgeComponent
    {
        public void Send(string messageType)
        {
            Console.WriteLine("Sending " + messageType + " using WebService");
        }
    }

    public class ThirdPartyAPI : IBridgeComponent
    {
        public void Send(string messageType)
        {
            Console.WriteLine("Sending " + messageType + " using ThirdPartyAPI");
        }
    }
}
