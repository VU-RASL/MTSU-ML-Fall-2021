using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Summary : MonoBehaviour
{
	Session sumSess = Session.Instance;
	public TMP_Text High;
	public TMP_Text Medium ;
	public TMP_Text Low;
	public TMP_Text SessionTime;

	private void Awake ()
	{
		sumSess.session.metaData.EndTime = DateTime.Now;
		sumSess.session.metaData.lengthOfSession = DateTime.Now - sumSess.session.metaData.StartTime;
		if(!High) {
			High = GetComponent<TMP_Text>();
			Medium = GetComponent<TMP_Text>();
			Low = GetComponent<TMP_Text>();
			SessionTime = GetComponent<TMP_Text>();
		}else{

			TimeSpan length = sumSess.session.metaData.lengthOfSession;
			High.text= sumSess.session.data.buttons.high.ToString();
			Medium.text= sumSess.session.data.buttons.medium.ToString();
			Low.text= sumSess.session.data.buttons.low.ToString();
			if(length.Minutes == 0)
			{
				SessionTime.text= length.Seconds.ToString() + " sec";
			}
			else
			{
				SessionTime.text= length.Minutes.ToString() + " mins";
			}
		}
	}

	public List<SessionData> GetJsonSessions(string path)
	{
		string file = File.ReadAllText(@path);
		return JsonConvert.DeserializeObject<List<SessionData>>(file);
	}

	public void NextSession()
	{
		WriteSession();
		sumSess.session = new SessionData();
		SceneManager.LoadScene(0);
	}
	public void WriteSession()
	{
		//Reads multiple sessions
		string datastore = File.ReadAllText(@"./Assets/DataStore.json");
		Debug.Log(datastore);
		var lastsessid = File.ReadAllText(@"./Assets/sessid.txt");
		sumSess.session.sessionId = Int32.Parse(lastsessid) + 1;
		string updatedJson;
		if(datastore == "")
		{
			updatedJson = JsonConvert.SerializeObject(sumSess.session);
			updatedJson = string.Format("[{0}]", updatedJson);
		}
		else
		{
			List<SessionData> sessions = GetJsonSessions("./Assets/DataStore.json");
			sessions.Add(sumSess.session);
			updatedJson = JsonConvert.SerializeObject(sessions);
		}
		File.WriteAllText(@"./Assets/sessid.txt", sumSess.session.sessionId.ToString());
		File.WriteAllText(@"./Assets/DataStore.json", updatedJson);
	}
	public void EndSession()
	{
		WriteSession();
		sumSess.session = new SessionData();
		UnityEditor.EditorApplication.isPlaying = false;
	}
}
