using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPortal : MonoBehaviour
{
    public void MoveScene(string target)
    {
        Debug.Log("MoveScene");
        if (target.Equals("Village"))
        {
            Debug.Log("Move to Village");
            SceneManager.LoadScene("Village");
        }   
        else if (target.Equals("Merge"))
        {
            Debug.Log("Move to Merge");
            SceneManager.LoadScene("Merge");
        }
    }
}
