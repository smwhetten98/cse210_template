using System;

public class Entry
{
	private string _date;
	private string _prompt;
	private string _response;

	public Entry(string date, string prompt, string response)
	{
		_date = date;
		_prompt = prompt;
		_response = response;
	}

	public string[] GetEntryData()
	{
		return new string[] {_date, _prompt, _response};
	}
}