
using System;
using System.Linq;

public class Solution
{
    public string[] ReorderLogFiles(string[] logs)
    {
        string[] sortedLogs = logs.OrderBy(log => CompareLogContentType(log))
            .ThenBy(log => CompareLogContentWhenItContainsOnlyLetters(log))
            .ThenBy(log => CompareLogIdentifiertWhenContentContainsOnlyLetter(log))
            .ToArray();

        return sortedLogs;
    }

    private int CompareLogContentType(string log)
    {
        int index = log.IndexOf(' ');

        if (char.IsLetter(log[index + 1]))
        {
            return -1;
        }
        return 0;
    }

    private string CompareLogContentWhenItContainsOnlyLetters(string log)
    {
        int index = log.IndexOf(' ');

        if (char.IsLetter(log[index + 1]))
        {
            return log.Substring(index + 1);
        }
        return "";
    }

    private string CompareLogIdentifiertWhenContentContainsOnlyLetter(string log)
    {
        int index = log.IndexOf(' ');

        if (char.IsLetter(log[index + 1]))
        {
            return log.Substring(0, index);
        }
        return "";
    }
}
