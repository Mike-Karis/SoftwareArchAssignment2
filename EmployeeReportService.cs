using System;
//using System.Windows.Forms;
namespace SoftArchAssignment2._1
{
    public partial class EmployeeReportService
    {
         private string report = "";

    public void addData(string data) {
        report += data;
    }

    public void outputReport() {
        Console.WriteLine( report);
    }

    public void clearReport() {
        report = "";
    }
    }
}