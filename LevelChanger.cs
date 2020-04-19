using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator Animator;
    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        Animator.SetTrigger("FadeOut");

    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void OnFadeComplete(int build)
    {
        SceneManager.LoadScene(build);
    }
    public void OnTextComplete()
    {
        Debug.Log(PlayerPrefs.GetInt("Build"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("Build"));
    }
    public IEnumerator Cheat()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (GameObject message in GameObject.FindGameObjectsWithTag("Message"))
        {
            message.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
        }

    }
}
