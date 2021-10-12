using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using AppData;

public class toJson : MonoBehaviour
{
    public Data data;
    private string file = "unityJson.txt";
    public GameObject nameInputField;
    public GameObject patientInputField;
    public GameObject codeInputField;

    public void Save() {
        data = new Data();
        data.name = nameInputField.GetComponent<Text>().text;
        data.code = codeInputField.GetComponent<Text>().text;
        data.patientId = patientInputField.GetComponent<Text>().text;
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    private void WriteToFile(string fileName, string json) {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream)) {
            writer.Write(json);
        }
    }

    private string GetFilePath(string fileName) {
        return Application.persistentDataPath + "/" + fileName;
    }
}
