// O - Open/Closed Principle

using System;

abstract class Payment
{
    public abstract void Pay();
}

class CreditCard : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Paid using Credit Card");
    }
}

class UPI : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Paid Using UPI");
    }
}

class Cash : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Paid Using Cash in Bank");
    }
}

class OC
{
    public void Process(Payment p)
    {
        p.Pay();
    }

    static void Main()
    {
        OC c = new OC();

        c.Process(new CreditCard());
        c.Process(new UPI());
        c.Process(new Cash());
    }
}