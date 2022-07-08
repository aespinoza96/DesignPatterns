/*
 * The idea of this demo is to demonstrate the Single Responsability Principle.
 * There is a class "Journal" which is created for the basics functionality of a Journal.
 * Then some functionality is needed like to save or to load a file.
 * So what would be better based off on this principle? The goal is to separate the persistence
 * functionality in a separate class "Persistence".
 */

using System.Diagnostics;
using static System.Console;

namespace SingleResponsabilityPrinciple
{
    public class Journal
    {
        private readonly List<string> _entries = new List<string>();

        private static int _count = 0;

        public int AddEntry(string text)
        {
            _entries.Add($"{++_count}: {text}");
            return _count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }

        /* Breaks single responsibility principle
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {
      
        }

        public void Load(Uri uri)
        {
      
        }
        */
    }

    // handles the responsibility of persisting objects
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
        
        public void Load(string filename)
        {
      
        }

        public void Load(Uri uri)
        {
      
        }
    }
    
    public class Demo
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            journal.AddEntry("I cried today.");
            journal.AddEntry("I ate a bug.");
            WriteLine(journal);

            Persistence persistence = new Persistence();
            string currentPath = Directory.GetCurrentDirectory();
            string directory = currentPath.Remove(currentPath.IndexOf("bin"));
            string filename = $@"{directory}files/journal.txt";
            persistence.SaveToFile(journal, filename);
            // If using windows remove the first parameter.
            Process.Start("open",filename);
        }
    }
}