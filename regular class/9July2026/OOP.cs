using System;

class OOP
{
    static void Main()
    {
        Employee e = new Employee();

        e.EmpName = "Prajwal";
        e.Salary = 100;

        Console.WriteLine(e.EmpName + "" + e.Salary);

        CompiletimePol c = new CompiletimePol();
        c.Search(101);
        c.Search(12345679);
        c.Search("Prajwal", "Ghawat");

        RuntimePoly r = new RuntimePoly();
        r.Checkout(new UpiPayment(), 500);
        r.Checkout(new CreditPayment(), 50000);
        r.Checkout(new NetBanking(), 12000);
    }


}