using System;

public class Abstracting : FileStorage
{
    public override void Upload(string filename)
    {
        Console.WriteLine("Uploading File: " + filename);
    }

}