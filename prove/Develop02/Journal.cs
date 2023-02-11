using System;

public class Journal
{
	private List<Entry> _entries = new List<Entry>();
	private Prompts prompts = new Prompts();
	private string _journalFilepath = "journal.txt";

	public void NewEntry()
	{
		string prompt = _GetPrompt();
		string response = _GetResponse(prompt);
		Entry newEntry = _CreateEntry(prompt, response);
		_AddEntry(newEntry);
	}

	public bool SaveEntries()
	{
		List<string> csvData = _buildCSVLines();
		return SaveLoad.SaveToFile(_journalFilepath, csvData);
	}

	private List<string> _buildCSVLines()
	{
		List<string> csvLines = new List<string>();
		foreach(Entry entry in _entries)
		{
			csvLines.Add(_formatCSVEntryData(entry));
		}
		return csvLines;
	}

	private string _formatCSVEntryData(Entry entry)
	{
		string[] entryData = entry.GetEntryData();
		for (int i = 0; i < entryData.Count(); i++)
		{
			entryData[i] = entryData[i].Replace(",", "~");
		}
		return string.Join(",", entryData);
	}

	public void LoadEntries()
	{
		List<string> entriesData = _GetEntriesData();
		List<Entry> loadedEntries = _BuildEntries(entriesData);
		if (loadedEntries.Count() > 0)
		{
			_entries = loadedEntries;
		}
	}

	public void DisplayEntries()
	{
		foreach (Entry entry in _entries)
		{
			string[] entryData = entry.GetEntryData();
			Console.WriteLine($"{entryData[0]} - {entryData[1]}");
			Console.WriteLine($"{entryData[2]}\n");
		}
	}

	private List<Entry> _BuildEntries(List<string> entriesData)
	{
		List<Entry> loadedEntries = new List<Entry>();

		if (entriesData.Count() > 0) {
			foreach (string entryData in entriesData)
			{
				string[] entryDataElements = entryData.Split(",");
				Entry newEntry = new Entry(entryDataElements[0].Replace("~", ","), entryDataElements[1].Replace("~", ","), entryDataElements[2].Replace("~", ","));
				loadedEntries.Add(newEntry);
			}
		}
		return loadedEntries;
	}

	private List<string> _GetEntriesData()
	{
		return SaveLoad.LoadFromFile(_journalFilepath);
	}

	private Entry _CreateEntry(string prompt, string response)
	{
		return new Entry(DateTime.Now.ToString(), prompt, response);
	}

	private string _GetPrompt()
	{
		return prompts.GetPrompt();
	}

	private string _GetResponse(string prompt)
	{
		Console.Write($"{prompt}\n>");
		return Console.ReadLine();
	}

	private bool _AddEntry(Entry newEntry)
	{
		_entries.Add(newEntry);
		return false;
	}
}