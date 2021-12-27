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
	Session sumSess = Session.Instance;

	public TMPro.TextMeshProUGUI HighTxt;
	public TMPro.TextMeshProUGUI MidTxt;
	public TMPro.TextMeshProUGUI LowTxt;
	public TMPro.TextMeshProUGUI SessionTime;

	void Start ()
	{
		sumSess.session.metaData.EndTime = DateTime.Now;
		sumSess.session.metaData.lengthOfSession = DateTime.Now - sumSess.session.metaData.StartTime;
		HighTxt.text = sumSess.session.data.buttons.high.ToString();
		MidTxt.text = sumSess.session.data.buttons.medium.ToString();
		LowTxt.text = sumSess.session.data.buttons.low.ToString();
		SessionTime.text = sumSess.session.metaData.lengthOfSession.ToString();
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
		int lastsessid = 0;
		if (File.Exists(Application.persistentDataPath + "/sessid.txt"))
			lastsessid = Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/sessid.txt"));
		sumSess.session.sessionId = lastsessid + 1;

		File.WriteAllText(Application.persistentDataPath + $"/{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}_DataStore.json", JsonConvert.SerializeObject(sumSess.session));
		File.WriteAllText(Application.persistentDataPath + "/sessid.txt", sumSess.session.sessionId.ToString());
	}
	public void EndSession()
	{
		WriteSession();
		sumSess.session = new SessionData();
		Application.Quit();
		# if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		# endif
	}
}
