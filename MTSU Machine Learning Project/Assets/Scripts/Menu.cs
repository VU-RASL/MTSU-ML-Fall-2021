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
        string codeId = "", id = "", nameId = "";
        codeId = CodeInputField.GetComponentInChildren<Text>().text;
        id = PatientInputField.GetComponentInChildren<Text>().text;
        nameId = NameInputField.GetComponentInChildren<Text>().text;
        Session menuSess = Session.Instance;
        menuSess.session.data.name = nameId;
        menuSess.session.data.patientId = id;
        menuSess.session.data.code = codeId;
 
        SceneManager.LoadScene(1);
    }
}
