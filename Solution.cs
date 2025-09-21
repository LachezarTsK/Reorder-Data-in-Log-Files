
using System;
using System.Linq;

public class Solution
{
    public string[] ReorderLogFiles(string[] logs)
    {
        string[] sortedLogs = logs.OrderBy(log => compareLogContentType(log))
            .ThenBy(log => compareLogContentWhenItContainsOnlyLetters(log))
            .ThenBy(log => compareLogIdentifiertWhenContentContainsOnlyLetter(log))
            .ToArray();

        return sortedLogs;
    }

    private int compareLogContentType(string log)
    {
        int index = log.IndexOf(' ');

        if (char.IsLetter(log[index + 1]))
        {
            return -1;
        }
        return 0;
    }

    private string compareLogContentWhenItContainsOnlyLetters(string log)
    {
        int index = log.IndexOf(' ');

        if (char.IsLetter(log[index + 1]))
        {
            return log.Substring(index + 1);
        }
        return "";
    }

    private string compareLogIdentifiertWhenContentContainsOnlyLetter(string log)
    {
        int index = log.IndexOf(' ');

        if (char.IsLetter(log[index + 1]))
        {
            return log.Substring(0, index);
        }
        return "";
    }
}
