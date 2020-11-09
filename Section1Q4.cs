using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{	
		string test = Console.ReadLine();
        int digitCount = test.ToCharArray().Where(x=> Char.IsDigit(x)).Count();
		
		if(digitCount == test.Length)
		{
			Console.WriteLine("the given string contains only digits");
		}
		else
		{
			Console.WriteLine("the given string contains not only digits");
		}
	}
}