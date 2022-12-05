using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class SceneFlowManager : MonoBehaviour
{
  
    public TMP_InputField playerInput;
    public void StartNew()
    {
        PersistentData.Instance.LoadRecord();
        PersistentData.Instance.playerName=playerInput.text;
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        PersistentData.Instance.SaveRecord();
        EditorApplication.ExitPlaymode();
#else
        SaveRecord();        
Application.Quit();
#endif
    }
}
