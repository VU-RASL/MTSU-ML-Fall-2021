using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Summary : MonoBehaviour
{
	Session sumSess = Session.Instance;

	public TMPro.TextMeshProUGUI StressCount;
	public TMPro.TextMeshProUGUI EngagementCount;
	public TMPro.TextMeshProUGUI NeutalCount;
	public TMPro.TextMeshProUGUI SessionTime;

	void Start ()
	{
		sumSess.session.metaData.EndTime = DateTime.Now;
		sumSess.session.metaData.lengthOfSession = DateTime.Now - sumSess.session.metaData.StartTime;
		StressCount.text = (sumSess.session.data.buttons.high + sumSess.session.data.buttons.medium + sumSess.session.data.buttons.low).ToString();
		EngagementCount.text = (sumSess.session.data.buttons.helping + sumSess.session.data.buttons.conversing + sumSess.session.data.buttons.amused).ToString();
		NeutalCount.text = (sumSess.session.data.buttons.neutral).ToString();
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
		SceneManager.LoadScene("Menu Page");
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
