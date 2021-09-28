using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject nameInputField;
    public GameObject textDisplay;

    public void storeName() {
        theName = nameInputField.GetComponent<Text>().text;

        // need to change this to save to save it in json file
        textDisplay.GetComponent<Text>().text = "Welcome " + theName + " to the game";
    }
}
