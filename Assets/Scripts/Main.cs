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
    public Session mainSess = Session.Instance;

    public void MainToSummary() 
    {
        SceneManager.LoadScene(2);
        //Transition to summary page
    }
    public void High()
    {
        mainSess.session.data.buttons.high++;
		mainSess.session.data.times.Add(new Time("h", mainSess.session.metaData.StartTime));
    }
    public void Med()
    {
        mainSess.session.data.buttons.medium ++;
		mainSess.session.data.times.Add(new Time("m", mainSess.session.metaData.StartTime));
    }
    public void Low()
    {
        mainSess.session.data.buttons.low++;
		mainSess.session.data.times.Add(new Time("l", mainSess.session.metaData.StartTime));
    }
}
