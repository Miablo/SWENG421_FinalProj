using GUI;
using System;


public class Source: SourceIF
{
	SourceIF fif;
	string[] removelist = new string[] { "!", "@", "#", "$", "%", "^", "&", "(", ")", "*" };

	public Source()
    {

    }
	public Source(SourceIF fif)
	{
		this.fif = fif;
	}
	
    public string[] GetData()
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
        //Console.WriteLine(line);
        string tempstring = "";
        for(int i = 0; i < line.Length; i++)
        {
            if(line[i] == '\n')
            {
                temp[t] = tempstring;
                tempstring = "";
                t++;
            }
            else
            {
                tempstring += line[i];
            }
        }
        return temp;
    }

    public string[] readLock()
    {
        return GetData();
    }

    public void saveLock(string[] str)
    {
        System.IO.File.WriteAllLines("E:/SWENG421/SWENG421_FinalProj/GUI/Properties/SaveDataBase.txt", str);
    }
}