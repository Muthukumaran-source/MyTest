using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
	}
}
public class AnimalKingDam
{
	public string Category {get; set;}
	public string Zone {get; set;}
	public ICollection<AnimalInfo> Animals {get; set;}
}

public class AnimalInfo
{
	public string AnimalName { get; set;}
	public string Category {get; set;}
	public int Age {get; set;}
	public string Gender {get; set;}
	public string Location {get; set;}
	public string CrySound {get; set;}
	public ICollection<Food> Foods {get; set;}
	public DateTime VisitingTime {get; set;}
	public bool Status {get; set;}
	public DateTime EntryDate {get; set;}
	public string ContactPerson {get; set;}
}

public class Food
{
	public string FoodName {get; set;}
	public int Quantity {get; set;}
	public bool Status {get; set;}
}