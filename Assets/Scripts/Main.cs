using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Diagnostics;

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

    [SerializeField] TMPro.TextMeshProUGUI HighStressCount;
    [SerializeField] TMPro.TextMeshProUGUI MediumStressCount;
    [SerializeField] TMPro.TextMeshProUGUI LowStressCount;
    [SerializeField] TMPro.TextMeshProUGUI HelpingCount;
    [SerializeField] TMPro.TextMeshProUGUI ConversingCount;
    [SerializeField] TMPro.TextMeshProUGUI AmusedCount;
    [SerializeField] TMPro.TextMeshProUGUI NeuralCount;
    [SerializeField] TMPro.TextMeshProUGUI Time;
    private Stopwatch TimeStopWatch = new Stopwatch();

    void Start()
    {
        TimeStopWatch.Start();
    }

    void Update() {
        Time.text = $"{TimeStopWatch.Elapsed.Minutes.ToString("00")}:{TimeStopWatch.Elapsed.Seconds.ToString("00")}:{TimeStopWatch.Elapsed.Milliseconds.ToString()[0]}";
    }

    public void MainToSummary() 
    {
        SceneManager.LoadScene(2);
        //Transition to summary page
    }
    private void IncrementTotalCount() {
        mainSess.session.metaData.numberOfClicks++;
    }
    public void High()
    {
        IncrementTotalCount();
        mainSess.session.data.buttons.high++;
        HighStressCount.text = mainSess.session.data.buttons.high.ToString();
        mainSess.session.data.times.Add(new Time("High Stress", mainSess.session.metaData.StartTime));
    }
    public void Med()
    {
        IncrementTotalCount();
        mainSess.session.data.buttons.medium++;
        MediumStressCount.text = mainSess.session.data.buttons.medium.ToString();
        mainSess.session.data.times.Add(new Time("Medium Stress", mainSess.session.metaData.StartTime));
    }
    public void Low()
    {
        IncrementTotalCount();
        mainSess.session.data.buttons.low++;
        LowStressCount.text = mainSess.session.data.buttons.low.ToString();
        mainSess.session.data.times.Add(new Time("Low Stress", mainSess.session.metaData.StartTime));
    }
    public void HelpingEachOther()
    {
        IncrementTotalCount();
        mainSess.session.data.buttons.helping++;
        HelpingCount.text = mainSess.session.data.buttons.helping.ToString();
        mainSess.session.data.times.Add(new Time("Helping Each Other", mainSess.session.metaData.StartTime));
    }
    public void Conversing()
    {
        IncrementTotalCount();
        mainSess.session.data.buttons.conversing++;
        ConversingCount.text = mainSess.session.data.buttons.conversing.ToString();
        mainSess.session.data.times.Add(new Time("Conversing", mainSess.session.metaData.StartTime));
    }
    public void Amused()
    {
        IncrementTotalCount();
        mainSess.session.data.buttons.amused++;
        AmusedCount.text = mainSess.session.data.buttons.amused.ToString();
        mainSess.session.data.times.Add(new Time("Amused", mainSess.session.metaData.StartTime));
    }
    public void Neutral()
    {
        IncrementTotalCount();
        mainSess.session.data.buttons.neutral++;
        NeuralCount.text = mainSess.session.data.buttons.neutral.ToString();
        mainSess.session.data.times.Add(new Time("Neutral", mainSess.session.metaData.StartTime));
    }
}
