using System;

// Delegate - type that holds a reference to a method
// Similar to function pointer

delegate void MessageDelegate(string msg);

class DelegateEG
{
    static void Display(string message)
    {
        Console.WriteLine(message);
    }

    static void Main()
    {
        // Func delegate
        Func<int, int, int> add = (a, b) => a + b;

        Console.WriteLine(add(588, 561));

        // Custom delegate
        MessageDelegate m = Display;

        m("Hello I am learning");
    }
}