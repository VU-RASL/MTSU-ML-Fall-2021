using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Singleton<T> : MonoBehaviour where T :Singleton<T>
{
    public static T Instance { get;  set; }

    public void Awake() {

        if(Instance != null) {
            Debug.LogErrorFormat("Two copies of singleton {0} in the scene: ({1}, {2}). Please ensure only one is present.", 
                (typeof(T)).FullName, Instance.name, name);
            Destroy(gameObject);
            return;
        }

        Instance = (T)this;
    }
}