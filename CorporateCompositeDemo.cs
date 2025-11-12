using System;
using System.Collections.Generic;

public abstract class OrganizationComponent
{
    protected string _name;
    public OrganizationComponent(string name) { _name = name; }

    public abstract void Display(int depth);
    public abstract decimal GetBudget();
    public abstract int GetEmployeeCount();
}

public class Employee : OrganizationComponent
{
    private string _position;
    private decimal _salary;

    public Employee(string name, string position, decimal salary) : base(name)
    {
        _position = position;
        _salary = salary;
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + $" Employee: {_name}, {_position}, Salary: {_salary:C}");
    }

    public override decimal GetBudget() => _salary;
    public override int GetEmployeeCount() => 1;
}

public class Department : OrganizationComponent
{
    private List<OrganizationComponent> _members = new List<OrganizationComponent>();

    public Department(string name) : base(name) { }

    public void Add(OrganizationComponent component) => _members.Add(component);
    public void Remove(OrganizationComponent component) => _members.Remove(component);

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + $" Department: {_name}");
        foreach (var member in _members)
            member.Display(depth + 2);
    }

    public override decimal GetBudget()
    {
        decimal total = 0;
        foreach (var member in _members)
            total += member.GetBudget();
        return total;
    }

    public override int GetEmployeeCount()
    {
        int count = 0;
        foreach (var member in _members)
            count += member.GetEmployeeCount();
        return count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Department headOffice = new Department("Head Office");

        Employee ceo = new Employee("John Smith", "CEO", 10000);
        Employee accountant = new Employee("Mary Jones", "Accountant", 4000);
        headOffice.Add(ceo);
        headOffice.Add(accountant);

        Department itDept = new Department("IT Department");
        itDept.Add(new Employee("Tom", "Developer", 3000));
        itDept.Add(new Employee("Jane", "System Admin", 3500));

        Department hrDept = new Department("HR Department");
        hrDept.Add(new Employee("Sara", "HR Manager", 3200));

        headOffice.Add(itDept);
        headOffice.Add(hrDept);

        headOffice.Display(1);

        Console.WriteLine($"\nTotal Budget: {headOffice.GetBudget():C}");
        Console.WriteLine($"Total Employees: {headOffice.GetEmployeeCount()}");
    }
}
