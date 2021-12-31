using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionData
{
    //Auto generated
    public int sessionId {get;set;}
    public Data data = new Data();
    public SessionMetaData metaData = new SessionMetaData();
}
public class SessionMetaData
{
    public DateTime StartTime = DateTime.Now;
    // Make sure to set end time after switching to the summary page
    public DateTime EndTime {get;set;} = new DateTime();
    public TimeSpan lengthOfSession {get;set;}  = new TimeSpan();
    public int numberOfClicks {get;set;} = 0;
}
public class Data
{
    public string name {get;set;} = "name";
    public string code {get;set;} = "";
    public string patientId {get;set;} = "";
    public string type {get;set;} = "";
    public ButtonData buttons = new ButtonData();
    public List<Time> times = new List<Time>();
}
public class ButtonData 
{
    public int high = 0;
    public int medium = 0;
    public int low = 0;
    public int helping = 0;
    public int amused = 0;
    public int conversing = 0;
    public int neutral = 0;
}
public class Time
{
    // For the default value to work a new Time object must be instantiated on each click
    public DateTime time = DateTime.Now;
    public TimeSpan timeClicked = new TimeSpan();
    public string buttonName = "";
    public Time(string name, DateTime sessionStartTime)
    {
        timeClicked = time - sessionStartTime;
        buttonName = name;
    }
}