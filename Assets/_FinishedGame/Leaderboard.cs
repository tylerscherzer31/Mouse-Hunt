using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Leaderboard
{
    public List<Entry> entries = new List<Entry>();

    public void SortList()
    {
        entries.Sort(SortingEntries);
        
    }
    static int SortingEntries(Entry one, Entry two)
    {
        return two.score.CompareTo(one.score);
    }
}
