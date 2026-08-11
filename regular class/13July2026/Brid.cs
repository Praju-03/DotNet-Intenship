
class Brid
{
    public void Fly()
    {
        Console.WriteLine("Flyingg");
    }
}

class Penguin : Brid
{
    public override void Dly()
    {
        throw new Exception("");
    }
}