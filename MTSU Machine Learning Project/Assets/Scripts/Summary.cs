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
	Session Session = Session.Instance;
	// Reads data from exisitng json file
	public List<SessionData> GetJsonSessions(string path)
	{
		string file = File.ReadAllText(@path);
		return JsonConvert.DeserializeObject<List<SessionData>>(file);
	}
	// Add a Session parameter and call WriteSession(Session) in the summary page
	public void AddSession()
	{
		//Reads multiple sessions
		List<SessionData> sessions = GetJsonSessions("./Assets/DataStore.json");

		// Sets meta data about the session
		Session.session.metaData.EndTime = DateTime.Now;
		Session.session.metaData.lengthOfSession = Session.session.metaData.StartTime - DateTime.Now;

		// Appends single session object to end of list to write to new json file
		sessions.Add(Session.session);
		var updatedJson = JsonConvert.SerializeObject(sessions);
		File.WriteAllText(@"./Assets/DataStore.json", updatedJson);
		SceneManager.LoadScene(0);
	}
	public void PrintSession()
	{
		Session.session.metaData.EndTime = DateTime.Now;
		Session.session.metaData.lengthOfSession = Session.session.metaData.StartTime - DateTime.Now;

		var updatedJson = JsonConvert.SerializeObject(Session.session);
		Debug.Log(updatedJson.ToString());
	}
}