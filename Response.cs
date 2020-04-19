using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Response", menuName = "Responses")]
public class Response : ScriptableObject
{
    public string ReponseText;
    public Prompt NextPrompt;
    public int NextSceneIndex; 
    public string NextDay;
    
}
