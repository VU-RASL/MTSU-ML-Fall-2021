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
    public Session Session = Session.Instance;

    public void MainToSummary(string id) 
    {
        SceneManager.LoadScene(2);
        //Transition to summary page
    }
    public void High()
    {
        Session.session.data.buttons.high++;
		Session.session.data.times.Add(new Time("h", Session.session.metaData.StartTime));
    }
    public void Med()
    {
        Session.session.data.buttons.medium ++;
		Session.session.data.times.Add(new Time("m", Session.session.metaData.StartTime));
    }
    public void Low()
    {
        Session.session.data.buttons.low++;
		Session.session.data.times.Add(new Time("l", Session.session.metaData.StartTime));
    }
}
