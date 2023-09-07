using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CreationalPatterns
{
    //The purpose of the singleton design pattern is to ensure that a class only has one
    //instance and provide a global point of access to it throughout the life of an application.
    //Access of one instance is preferred to avoid unexpected results.

    // For example, you want to take a user's vote on something wherein you don't want double
    // counting and also missed any counting of the vote.Here, you can use the singleton pattern
    // with a Vote class to make sure only one instance of the Vote class is created and used to
    // count each user's vote.

    //you can implement logging functionality in your application using the singleton pattern where
    //one global instance of the logger class is used to log all information throughout the application.


    // A class should have the following structure for singleton pattern:
    // a. Should have a private or protected constructor.No public and parameterized constructors.
    // b. Should have a static property(with a private backing field) to return an instance of a class.
    // A static method can also be used to return an instance.
    // c. At least have one non-static public method for a singleton operation.


    // No Thread Safe Singleton
    // The following code is not thread-safe.
    // Two different threads could both have evaluated the test(if instance == null) and found it to be true,
    // then both create instances, which violates the singleton pattern.
    public sealed class Singleton1
    {
        // It has a private parameterless constructor which will restrict the creation of an object using the new keyword
        // You can make the constructor protected if you want to allow it to be inherited in a subclass.
        private Singleton1() { }

        private static Singleton1? instance = null;

        

        // Singleton class uses the static property to return an instance of the class
        // You must use the Instance property to get its object.
        public static Singleton1 Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singleton1();
                }
                return instance;
            }
        }
        public void Ring()
        {
            Console.WriteLine("Ding! Order Up!");
        }
    }

    // Thread Safety Singleton
    // In the code, the thread is locked on a shared object and checks whether an instance has been created or not.
    // It takes care of the memory barrier issue and ensures that only one thread will create an instance.For example:
    // Since only one thread can be in that part of the code at a time, by the time the second thread enters it,
    // the first thread will have created the instance, so the expression will evaluate as false.
    // The biggest problem with this is performance; performance suffers since a lock is required every time an instance is requested.
    public sealed class Singleton2
    {
        private Singleton2() { }
        private static readonly object lockObject = new object();
        private static Singleton2? instance = null;
        public static Singleton2 Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Singleton2();
                    }
                }
                return instance;
            }
        }
        public void Ring()
        {
            Console.WriteLine("Ding! Order Up!");
        }
    }

    // Thread Safety Singleton using Double-Check Locking
    // In the following code, the thread is locked on a shared object and checks whether
    // an instance has been created or not with double checking.
    public sealed class Singleton3
    {
        private Singleton3() { }
        private static readonly object lockObject = new object();
        private static Singleton3? instance = null;

        public static Singleton3 Instance
        {
            get {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton3();
                        }
                    }
                }
                    return instance;
                }
            }
        public void Ring()
        {
            Console.WriteLine("Ding! Order Up!");
        }
    }

    // Thread Safe Singleton without using locks and no lazy instantiation
    // The preceding implementation looks like a very simple code.
    // This type of implementation has a static constructor, so it executes only once per Application Domain.
    // It is not as lazy as the other implementation.

    public sealed class Singleton4
    {
        private static readonly Singleton4? instance = null;

        // Explicit static constructor to force the C#
        // compiler not to mark the type as beforefieldinit
        static Singleton4() { }
        private Singleton4() { }
        public static Singleton4 Instance
        {
            get
            {
                return instance;
            }
        }
        public void Ring()
        {
            Console.WriteLine("Ding! Order Up!");
        }
    }

    // Using .NET 4's Lazy<T> type
    // If you are using .NET 4 or higher then you can use the System.Lazy<T> type to make the laziness really simple.
    // You can pass a delegate to the constructor that calls the Singleton constructor, which is done most easily with a lambda expression.
    // Allows you to check whether or not the instance has been created with the IsValueCreated property. 
    public sealed class Singleton5
    {
        private Singleton5() { }
        private static readonly Lazy <Singleton5> lazy = new Lazy<Singleton5>(() => new Singleton5());
        public static Singleton5 Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public void Ring()
        {
            Console.WriteLine("Ding! Order Up!");
        }
    }


}
