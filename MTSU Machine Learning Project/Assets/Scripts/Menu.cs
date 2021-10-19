using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

/*
Menu functions
--- Instantiate new session variable
--- Set name, patientId, code
--- Pass current session to Main constructor Main(session)
--- Transition to next scene
*/
public class Menu : MonoBehaviour
{
    public GameObject nameInputField;
    public GameObject patientInputField;
    public GameObject codeInputField;
    public void MenuToMain()
    {
        Session.Instance.Awake();
        Debug.Log(Session.Instance.sessionId);

        SceneManager.LoadScene(1);
    }
}
