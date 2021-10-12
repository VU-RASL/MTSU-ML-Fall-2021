using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using AppData;


public class Summary : MonoBehaviour
{
	// These would be initialized in the dataclass
	public Session session = new Session();
	// public Text high;
	// public Text medium;
	// public Text low;
	// public Text lengthOfSession;

	// Only here as example usage. The variables would be 
	// set through the lifespan of the session
	// Summary(Session session)
	Summary()
	{
		session.sessionId = "sesisonid2";

		session.data.name = "testname";
		session.data.code = "one";
		session.data.patientId = "12341";

		session.data.buttons.high = 3;
		session.data.buttons.medium = 2;
		session.data.buttons.low = 1;
		session.data.times = new List<AppData.Time>()
		{ 
			new AppData.Time("High"),
			new AppData.Time("Low") 
		};

		// high.text = session.data.buttons.high.ToString();
		// medium.text = session.data.buttons.medium.ToString();
		// low.text = session.data.buttons.low.ToString();
		// lengthOfSession.text = session.metaData.lengthOfSession.ToString();
	}

	// Reads data from exisitng json file
	public List<Session> GetJsonObjects(string path)
	{
		string file = File.ReadAllText(@path);
		return JsonConvert.DeserializeObject<List<Session>>(file);
	}
	// Add a Session parameter and call WriteSession(Session) in the summary page
	public void WriteSession()
	{
		//Reads single session
		// Session testwrite = GetJsonObject("./Assets/loadtest.json");

		//Reads multiple sessions
		List <Session> sessions = GetJsonObjects("./Assets/DataStore.json");

		Debug.Log(sessions.ToString());
		foreach(var item in sessions)
		{
			Debug.Log(item.ToString());
		}
		// Sets meta data about the session
		session.metaData.EndTime = DateTime.Now;
		session.metaData.lengthOfSession = session.metaData.StartTime - DateTime.Now;

		// Appends single session object to end of list to write to new json file
		sessions.Add(session);
		var updatedJson = JsonConvert.SerializeObject(sessions);
		File.WriteAllText(@"./Assets/DataStore.json", updatedJson);
	}
}