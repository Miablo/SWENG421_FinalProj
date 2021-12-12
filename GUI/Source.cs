using GUI;
using System;


public class Source: SourceIF
{
	SourceIF fif;
	string[] lines;
	string[] removelist = new string[] { "!", "@", "#", "$", "%", "^", "&", "(", ")", "*" };

	public Source()
    {

    }
	public Source(SourceIF fif)
	{
		this.fif = fif;
	}
	public Source(string[] line)
    {
		this.lines = line;
    }

    public void GetData()
    {
		string line = (System.IO.File.ReadAllText("E:/SWENG421/SWENG421_FinalProj/GUI/DatabaseFile.txt"));
        string[] temp = new string[line.Length];
        int t = 0;

        for(int i = 0; i < removelist.Length; i++)
        {
            if (line.Contains(removelist[i]))
            {
               line = line.Replace(removelist[i], "");
            }
        }
        Console.WriteLine(line);
    }
}