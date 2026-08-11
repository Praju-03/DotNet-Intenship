// I - Interface Segregation Principle
// Clients should not be forced to implement methods they do not need

using System;

interface Program
{
    void Work();
    void Walk();
    void eat();
}

class Human : Program
{
    public void Work()
    {
        Console.WriteLine("Human is working");
    }

    public void Walk()
    {
        Console.WriteLine("Human is walking");
    }

    public void eat()
    {
        Console.WriteLine("Human is eating");
    }
}

class Test
{
    static void Main()
    {
        Human h = new Human();

        h.Work();
        h.Walk();
        h.eat();
    }
}