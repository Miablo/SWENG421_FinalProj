using GUI;
using System;


public class Source: SourceIF
{
	SourceIF fif;
	string[] removelist = new string[] { "!", "@", "#", "$", "%", "^", "&", "(", ")", "*" };

    private int waitingForReadLock = 0;
    private int outstandingReadLocks = 0;

    // The thread that has the write lock or null.
    private Thread writeLockedThread;

    private ArrayList waitingForWriteLock = new ArrayList();

	public Source()
    {

    }
	public Source(SourceIF fif)
	{
		this.fif = fif;
	}
	
    public string[] GetData()
    {
		string line = (System.IO.File.ReadAllText("/Desktop/SWENG421_FinalProj/GUI/DatabaseFile.txt"));
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

    public void ReadLock(){
        //throw new NotImplementedException();
        if  (writeLockedThread != null) {
            waitingForReadLock++;
            while (writeLockedThread != null) {
                wait();
            }
            waitingForReadLock--;
        }
        outstandingReadLocks++;
    }

    public void WriteLock(){
        //throw new NotImplementedException();
        Thread thisThread;
        synchronized (this) {
            if (writeLockedThread==null && outstandingReadLocks==0) {
                writeLockedThread = Thread.currentThread();
                return;
            }
            thisThread = Thread.currentThread();
            waitingForWriteLock.add(thisThread);
        }
        synchronized (thisThread) {
            while (thisThread != writeLockedThread) {
                thisThread.wait();
            }
        }
        synchronized (this) {
            waitingForWriteLock.remove(thisThread);
        }
    }

    //decide the next thread (user) to have access to the data (the inventory list)
    public void Done(){
        //throw new NotImplementedException();
        if (outstandingReadLocks > 0) {
            outstandingReadLocks--;
            if ( outstandingReadLocks==0 && waitingForWriteLock.size()>0) {
                writeLockedThread = (Thread)waitingForWriteLock.get(0);
                synchronized (writeLockedThread) {
                    writeLockedThread.notifyAll();
                }
            }
        } else if (Thread.currentThread() == writeLockedThread) {
            if ( outstandingReadLocks==0 && waitingForWriteLock.size()>0) {
                writeLockedThread = (Thread)waitingForWriteLock.get(0);
                synchronized (writeLockedThread) {
                    writeLockedThread.notifyAll();
                }
            } else {
                writeLockedThread = null;
                if (waitingForReadLock > 0)
                    notifyAll();
            }
        } else {
            throw new IllegalStateException("Thread does not have lock");
        }
    }
}