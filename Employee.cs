using System;
namespace SoftArchAssignment2._1
{
    public class Employee
    {
    private /*final*/ string REQUIRED_MSG = " is mandatory ";
    private /*final*/ string NEWLINE = "\n";

    private string firstName;
    private string lastName;
    private string ssn;
    private bool metWithHr;
    private bool metDeptStaff;
    private bool reviewedDeptPolicies;
    private bool movedIn;
    private string cubeId;
    private DateTime orientationDate;
    private EmployeeReportService reportService = new EmployeeReportService();

    public Employee(string firstName, string lastName, string ssn) {
        setFirstName(firstName);
        setLastName(lastName);
        setSsn(ssn);
    }

    private string getFormattedDate() {
        return orientationDate.ToString("M/d/yy");
    }

    public void doFirstTimeOrientation(string cubeId) {
        orientationDate = DateTime.Now;
        meetWithHrForBenefitAndSalaryInfo();
        meetDepartmentStaff();
        reviewDeptPolicies();
        moveIntoCubicle(cubeId);
    }

    private void meetWithHrForBenefitAndSalaryInfo() {
        metWithHr = true;
        reportService.addData(firstName + " " + lastName + " met with HR on "
                + getFormattedDate() + NEWLINE);
    }

    private void meetDepartmentStaff() {
        metDeptStaff = true;
        reportService.addData(firstName + " " + lastName + " met with dept staff on "
                + getFormattedDate() + NEWLINE);
    }

    public void reviewDeptPolicies() {
        reviewedDeptPolicies = true;
        reportService.addData(firstName + " " + lastName + " reviewed dept policies on "
                + getFormattedDate() + NEWLINE);
    }

    public void moveIntoCubicle(string cubeId) {
        setCubeId(cubeId);

        this.movedIn = true;
        reportService.addData(firstName + " " + lastName + " moved into cubicle "
                + cubeId + " on " + getFormattedDate() + NEWLINE);
    }

    public string getFirstName() {
        return firstName;
    }

    public void setFirstName(string firstName) {
        if (firstName == null || string.IsNullOrEmpty(firstName)) {
            throw new ArgumentOutOfRangeException("first name" + REQUIRED_MSG);
        }
        this.firstName = firstName;
    }

    public string getLastName() {
        return lastName;
    }

    public void setLastName(string lastName) {
        if (lastName == null || string.IsNullOrEmpty(lastName)) {
            throw new ArgumentOutOfRangeException("last name" + REQUIRED_MSG);
        }
        this.lastName = lastName;
    }

    public string getSsn() {
        return ssn;
    }

    public void setSsn(string ssn) {
        if (ssn == null || ssn.Length < 9 || ssn.Length > 11) {
            throw new ArgumentOutOfRangeException("ssn" + REQUIRED_MSG + "and must be between 9 and 11 characters (if hyphens are used)");
        }
        this.ssn = ssn;
    }

    public bool hasMetWithHr() {
        return metWithHr;
    }

    public bool hasMetDeptStaff() {
        return metDeptStaff;
    }

    public bool hasReviewedDeptPolicies() {
        return reviewedDeptPolicies;
    }

    public bool hasMovedIn() {
        return movedIn;
    }

    public string getCubeId() {
        return cubeId;
    }

    public void setCubeId(string cubeId) {
        if (cubeId == null || string.IsNullOrEmpty(cubeId)) {
            throw new ArgumentOutOfRangeException("cube id" + REQUIRED_MSG);
        }
        this.cubeId = cubeId;
    }

    public DateTime getOrientationDate() {
        return orientationDate;
    }

    // public void setOrientationDate(DateTime orientationDate) {
    //     if (orientationDate == null) {
    //         throw new ArgumentOutOfRangeException("orientationDate" + REQUIRED_MSG);
    //     }
    //     this.orientationDate = orientationDate;
    // }

    public void printReport() {
        reportService.outputReport();
    }

    //@Override
    public string toString() {
        return "Employee{" + "firstName=" + firstName + ", lastName=" + lastName + ", ssn=" + ssn + '}';
    }
    }
}