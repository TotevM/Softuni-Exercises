using System;
using ValidationAttributes.Models;

namespace ValidationAttributes;

public class StartUp
{
    public static void Main(string[] args)
    {
        Person person = new(null, -1);
        Console.WriteLine(Utils.Validator.IsValid(person));
    }
}