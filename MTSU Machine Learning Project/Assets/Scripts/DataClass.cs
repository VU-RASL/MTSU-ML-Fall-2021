using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppData
{
    public class SessionMetaData
    {
    public DateTime StartTime = DateTime.Now;
    // Make sure to set end time after switching to the summary page
	public DateTime EndTime {get;set;} = new DateTime();
	public TimeSpan lengthOfSession {get;set;}  = new TimeSpan();
    public int numberOfClicks {get;set;} = 0;
    }
    public class Session 
    {
        //Auto generated
        public string sessionId {get;set;}
        public Data data = new Data();
        public SessionMetaData metaData = new SessionMetaData();
    }

    public class Data
    {
        public string name {get;set;}
        public string code {get;set;}
        public string patientId {get;set;}
        public ButtonData buttons = new ButtonData();
        public List<Time> times = new List<Time>();
    }
    public class ButtonData 
    {
        public int high {get;set;} = 0;
        public int medium {get;set;} = 0;
        public int low {get;set;} = 0;
    }
    public class Time
    {
        // For the default value to work a new Time object must be instantiated on each click
        public DateTime time {get;set;} = DateTime.Now;
        public string buttonName {get;set;} 
        public Time(string name)
        {
            buttonName = name;

        }
    }

};
