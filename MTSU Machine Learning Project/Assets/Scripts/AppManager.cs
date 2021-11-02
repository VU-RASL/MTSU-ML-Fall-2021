using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Session{
    public SessionData session = new SessionData();
    private static Session _instance;
    public static Session Instance 
    {
        get
        {
            if (_instance == null)
                _instance = new Session();
            return _instance;
        }
    }
	public void PrintSession()
	{
		session.metaData.EndTime = DateTime.Now;
		session.metaData.lengthOfSession = session.metaData.StartTime - DateTime.Now;

		var updatedJson = JsonConvert.SerializeObject(session);
        Debug.Log(updatedJson);
	}
}