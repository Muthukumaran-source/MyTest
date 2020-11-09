using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
	}
}
public class DirectoryInfo
{
	public string DirectoryName {get; set;}
	public ICollection<FileSystem> FileSystems {get; set;}
}

public class FileSystem
{
	public string Attributes { get; set;}
	public DateTime CreationTime {get; set;}
	public string Directory {get; set;}
	public bool Exists {get; set;}
	public string Extension {get; set;}
	public string FullName {get; set;}
	public DateTime LastAccessTime {get; set;}
	public DateTime LastWriteTime {get; set;}
	public int Length {get; set;}
	public string Name {get; set;}
}