using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

// the Builder Design Pattern builds a complex object using many simple objects
// and using a step-by-step approach. The Process of constructing a complex object
// should be generic so that the same construction process can be used to create
// different representations of the same complex object.

// the Builder Design Pattern is all about separating the construction process from
// its representation. When the construction process of your object is very complex
// then only you need to use to Builder Design Pattern.

//Abstract Builder: The Builder is an interface that defines all the steps which are used
//to make the concrete product. 

//Concrete Builder: The Concrete Builder Classes implements the Abstract Builder interface
//and provides implementation to all the abstract methods.The Concrete Builder is responsible
//for constructing and assembling the individual parts of the product by implementing the
//Builder interface. It also defines and tracks the representation it creates.

//Director: The Director takes those individual processes from the Builder and defines
//the sequence to build the product.

//Product: The Product is a class and we want to create this product object using the
//builder design pattern. This class defines different parts that will make the product.

namespace CreationalPatterns
{
    // We are creating the Product here
    public class Report
    {
        public string? ReportType { get; set; }
        public string? ReportHeader { get; set; }
        public string? ReportFooter { get; set; }
        public string? ReportContent { get; set; }

        public void DisplayReport()
        {
            Console.WriteLine(" Report Type: " + ReportType);
            Console.WriteLine(" Header: " + ReportHeader);
            Console.WriteLine(" Content: " + ReportContent);
            Console.WriteLine(" Footer: " + ReportFooter);
        }
    }

    // We are creating the Abstract Builder Class here

    // this class provides the blueprint to create different types of products.
    // As it is abstract, it can have the capabilities to have both abstract and non-abstract methods.
    // The subclasses are going to implement
    public abstract class ReportBuilder
    {
        public Report? reportObject;

        // here we have four abstract methods.So, each subclass of ReportBuilder will
        // need to implement those four abstract methods in order to properly build a report.
        public abstract void SetReportType();
        public abstract void SetReportHeader();
        public abstract void SetReportContent();
        public abstract void SetReportFooter();

        public void CreateNewReport()
        {
            reportObject = new Report();
        }
        public Report GetReport()
        {
            return reportObject;
        }
    }

    // We are creating Concrete Builder Classes here

    //The Concrete Builder classes follow the Builder interface and provide specific
    //implementations of the building steps.The Application may have several variations
    //of Builders, implemented differently.In our example, we are dealing with two types
    //of reports i.e.Excel and PDF.


    //This ExcelReport class implements the ReportBuilder abstract class and implements the four abstract
    //methods which is the blueprint for creating the report objects.This class is basically used to provide
    //the blueprint for creating the Excel Report.
    public class ExcelReport: ReportBuilder
    {
        public override void SetReportContent()
        {
            reportObject.ReportContent = "Excel Content Section";
        }

        public override void SetReportFooter()
        {
            reportObject.ReportFooter = "Excel Footer";
        }

        public override void SetReportHeader()
        {
            reportObject.ReportHeader = "Excel Header";
        }

        public override void SetReportType()
        {
            reportObject.ReportType = "Excel";
        }
    }

    // This class also implements the ReportBuilder abstract class and implements the four abstract
    // methods which is the blueprint for creating the report objects. The following PDFReport class
    // is used to create the Report in PDF format.

    public class PDFReport : ReportBuilder
    {
        public override void SetReportContent()
        {
            reportObject.ReportContent = "PDF Content Section";
        }

        public override void SetReportFooter()
        {
            reportObject.ReportFooter = "PDF Footer";
        }

        public override void SetReportHeader()
        {
            reportObject.ReportHeader = "PDF Header";
        }

        public override void SetReportType()
        {
            reportObject.ReportType = "PDF";
        }
    }

    // We are creating Director here

    // The Director is only responsible for executing the building steps in a particular order. 
    // It is helpful when producing products according to a specific order or configuration.
    public class ReportDirector 
    {
        public Report MakeReport(ReportBuilder reportBuilder)
        {
            reportBuilder.CreateNewReport();
            reportBuilder.SetReportType();
            reportBuilder.SetReportHeader();
            reportBuilder.SetReportContent();
            reportBuilder.SetReportFooter();

            return reportBuilder.GetReport();
        }
    }

}
