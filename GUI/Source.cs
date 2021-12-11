using System;


public class Source
{
	public Source()
	{
		return getData();
	}

	private string[] getData()
	{
		string[] lines =
			System.IO.File.ReadAllLines("InventoryList.txt");
		foreach (string line in lines)
		{
			Console.WriteLine(line);
		}
		return lines;
	}
}