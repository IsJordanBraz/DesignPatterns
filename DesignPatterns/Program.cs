using System;
using System.Diagnostics;

namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> _entries = new List<string>();
        private static int _count = 0;

        public int AddEntry(string text)
        {
            _entries.Add($"{++_count}: {text}");
            return _count;
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I learning a new language");
            j.AddEntry("I learning CSharp");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\jornal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}