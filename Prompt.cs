using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Prompt", menuName ="Prompts")]
public class Prompt : ScriptableObject
{
    public string PromptText;
    public string NextScene;
    public string NextDay;
    public List<Response> PlayerResponses = new List<Response>(); 
}
