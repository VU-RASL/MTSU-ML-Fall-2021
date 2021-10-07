using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using AppData;

public class SummaryActions : MonoBehaviour
{
	//Function mostly for testing purposes
	public static Session GetJsonObject(string path)
	{
		string file = File.ReadAllText(@path);
		return JsonConvert.DeserializeObject<Session>(file);
	}

	public static List<Session> GetJsonObjects(string path)
	{
		string file = File.ReadAllText(@path);
		return JsonConvert.DeserializeObject<List<Session>>(file);
	}
	public static void WriteJsonFile()
	{
		//Reads single session
		Session session = GetJsonObject("./Assets/loadtest.json");
		//Reads multiple sessions
		List <Session> sessions = GetJsonObjects("./Assets/testdata.json");
		//Appends single session to end of list to write to new json file
		sessions.Add(session);
		var updatedJson = JsonConvert.SerializeObject(sessions);
		File.WriteAllText(@"./Assets/testdata.json", updatedJson);
	}
}