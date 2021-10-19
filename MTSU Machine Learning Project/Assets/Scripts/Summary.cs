using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Summary : MonoBehaviour
{
	public Summary()
	{
		PrintSession();
	}

	// Reads data from exisitng json file
	public List<Session> GetJsonSessions(string path)
	{
		string file = File.ReadAllText(@path);
		return JsonConvert.DeserializeObject<List<Session>>(file);
	}
	// Add a Session parameter and call WriteSession(Session) in the summary page
	public void AddSession()
	{
		var session = Session.Instance;
		//Reads multiple sessions
		List <Session> sessions = GetJsonSessions("./Assets/DataStore.json");

		// Sets meta data about the session
		session.metaData.EndTime = DateTime.Now;
		session.metaData.lengthOfSession = session.metaData.StartTime - DateTime.Now;

		// Appends single session object to end of list to write to new json file
		sessions.Add(session);
		var updatedJson = JsonConvert.SerializeObject(sessions);
		File.WriteAllText(@"./Assets/DataStore.json", updatedJson);
		SceneManager.LoadScene(0);
	}
	public void PrintSession()
	{
		// session.metaData.EndTime = DateTime.Now;
		// session.metaData.lengthOfSession = session.metaData.StartTime - DateTime.Now;

		// var updatedJson = JsonConvert.SerializeObject(session);
		Debug.Log("In Summary");
	}
}