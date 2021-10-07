using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppData
{
    public class Session 
    {
        //Auto generated
        public string sessionId {get;set;}
        public Data data {get;set;}
    }

    public class Data
    {
        public string name {get;set;}
        public string code {get;set;}
        public string patientId {get;set;}
        public ButtonData buttons {get;set;}
        public List<Time> times {get;set;}
    }
    public class ButtonData 
    {
        public int high {get;set;}
        public int medium {get;set;}
        public int low {get;set;}
    }
    public class Time
    {
        public int mins {get;set;}
        public int seconds {get;set;}
        public string buttonName {get;set;}
    }

};
