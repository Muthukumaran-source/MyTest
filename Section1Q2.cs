using System;
					
public class Program
{
	public static void Main()
	{
		int m = 0, reminder =0, rn = 0;
		Console.WriteLine("Please enter a number: ");
		m = validation();	
		
		while(m > 0)
		{ 
			rn *= 10;
        	reminder = m % 10;              
        	m = (m - reminder) / 10;
			rn += reminder;
		}
		
		Console.WriteLine("Reversed number is " + rn);
	}
	
	public static int validation()
	{
		int number =0;
		if(!int.TryParse(Console.ReadLine(), out number))
		{
			Console.WriteLine("please enter a valid number");
			Console.ReadLine();
		}
		return number;
	}
}