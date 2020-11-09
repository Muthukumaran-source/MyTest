using System;
					
public class Program
{
	public static void Main()
	{
		int m = 0, n =0;
		Console.WriteLine("Please enter m: ");
		m = validation();	
		
		Console.WriteLine("Please enter n: ");
		n = validation();
		
		string s1 = string.Empty, s2 = string.Empty;
		for(int i= 1; i<=n; i++)
		{
			Console.WriteLine(i*m);
		}
	}
	
	public static int validation()
	{
		int number =0;
		if(!int.TryParse(Console.ReadLine(), out number) || number > 20)
		{
			Console.WriteLine("number must be less than 20");
			Console.ReadLine();
		}
		return number;
	}
}