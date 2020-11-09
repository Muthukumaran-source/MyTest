using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
	}
}
public class RestaurantInfo
{
	public int RestaurantID {get; set;}
	public string RestaurantName {get; set;}
	public string Address {get; set;}
	public string Location {get; set;}
	public ICollection<Menu> Menus {get; set;}
	public ICollection<Table> Tables {get; set;}
	public string Timing {get; set;}
	public bool Status  {get; set;}
}

public class Menu
{
	public int MenuID { get; set;}
	public string MenuCategory {get; set;}
	public string ItemName {get; set;}
	public string ItemCategory {get; set;}
	public int Quantity {get; set;}
	public decimal price {get; set;}
	public decimal discount {get; set;}
	public bool Status {get; set;}
	public DateTime AvailableTime {get; set;}
	public string ChefName {get; set;}
}

public class Table
{
	public int TableID {get; set;}
	public int NumberOfSeats {get; set;}
	public bool Status {get; set;}
	public string AttenderName {get; set;}
}

public class Reservation
{
	public int ReservationID {get; set;}
	public int RestaurantID {get; set;}
	public int TableID {get; set;}
	public string CustomerID {get; set;}
	public int NumberOfSeats {get; set;}
	public DateTime ReservationTime {get; set;}
	public int BillNumber {get; set;}
}

public class Customer
{
	public int CustomerID {get; set;}
	public string CustomerName {get; set;}
	public string Address {get; set;}
	public string ContactNumber {get; set;}
	public string EmailAddress {get; set;}
}