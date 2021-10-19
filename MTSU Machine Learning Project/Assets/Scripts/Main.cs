using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

/*
Menu functions
--- Increment number of clicks for each button
--- Add time objects to session.data.times array on click
--- Pass current session to Summary constructor Summary(session)
--- Transition to next scene
*/
public class Main : MonoBehaviour
{

    public Time[] times;
    public Session session = Session.Instance;

    public void MainToSummary(string id) 
    {
        SceneManager.LoadScene(2);
        //Transition to summary page
    }
    public void High()
    {
        session.data.buttons.high++;
		session.data.times.Add(new Time("h", session.metaData.StartTime));
        Debug.Log(session.data.buttons.high);
    }
    public void Med()
    {
        session.data.buttons.medium ++;
		session.data.times.Add(new Time("m", session.metaData.StartTime));
        Debug.Log(session.data.buttons.medium);
    }
    public void Low()
    {
        session.data.buttons.low++;
		session.data.times.Add(new Time("l", session.metaData.StartTime));
        Debug.Log(session.data.buttons.low);
    }
}
