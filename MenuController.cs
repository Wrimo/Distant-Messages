using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().FadeToLevel(1);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
