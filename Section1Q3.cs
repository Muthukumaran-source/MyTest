using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{	
		string test = Console.ReadLine();
        var result = test.GroupBy(c => c).Where(c => c.Count() > 1).Select(c => new { charName = c.Key, charCount = c.Count()});
		
		foreach(var c in result)
		{
			Console.WriteLine(c.charName + " : " + c.charCount);
		}
	}
}