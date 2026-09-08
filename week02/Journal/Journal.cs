public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry _entry in _entries)
        {
            _entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry _entry in _entries)
            {
                outputFile.WriteLine($"{_entry._date} | {_entry._promptText} | {_entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line;
            _entries.Clear();
            while ((line = inputFile.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0].Trim();
                    entry._promptText = parts[1].Trim();
                    entry._entryText = parts[2].Trim();
                    _entries.Add(entry);
                }
            }
        }
    }

}