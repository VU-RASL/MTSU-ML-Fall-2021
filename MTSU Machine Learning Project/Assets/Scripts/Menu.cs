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
    public GameObject NameInputField;
    public GameObject PatientInputField;
    public GameObject CodeInputField;
    public void MenuToMain()
    { 
        print(CodeInputField.GetComponent<Text>().text);
        string code = CodeInputField.GetComponent<Text>().text;
        string id = PatientInputField.GetComponent<Text>().text;
        string name = NameInputField.GetComponent<Text>().text;
        Session Session = Session.Instance;
        Session.session.data.name = name;
        Session.session.data.patientId = id;
        Session.session.data.code = code;

        Session.PrintSession(); 
        SceneManager.LoadScene(1);
    }
}
