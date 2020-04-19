using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    public Prompt startEvent;
    public Button choice1Button;
    public Button choice2Button;
    public Button choice3Button;

    private Response Choice1;
    private Response Choice2;
    private Response Choice3;

    public GameObject ResponseTemplate;
    public GameObject PromptTemplate;
    public GameObject TextTemplate;

    public Transform Canvas;
    public TextMeshProUGUI time;

    string[] times = new string[] { "11:06", "9:01", "12:00", "5:00", "8:59", "1:24", "7:46", "3:15", "6:11", "10:33", "10:30", "11:05", "12:05", "3:20", "9:10", "11:50", "3:45", "3:55", "4:30", "11:00", "2:45", "3:05", "7:05", "9:10", "9:45", "11:10" };

    void Start()
    {
            sendPrompt(startEvent);

    }

    private void displayPlayerChoices(Prompt eventInfo)
    {
        List<Response> choices = eventInfo.PlayerResponses;

        try
        {
            if (choices.Count > 0)
            {
                choice1Button.GetComponent<Image>().enabled = true;
                choice1Button.GetComponent<Button>().enabled = true;
                choice1Button.GetComponentInChildren<TextMeshProUGUI>().text = choices.ElementAt(0).ReponseText;
                Choice1 = choices.ElementAt(0);
            }
            else
            {
                choice1Button.GetComponent<Image>().enabled = false;
                choice1Button.GetComponent<Button>().enabled = false;
                choice1Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }

            if (choices.Count > 1)
            {
                choice2Button.GetComponent<Image>().enabled = true;
                choice2Button.GetComponent<Button>().enabled = true;
                choice2Button.GetComponentInChildren<TextMeshProUGUI>().text = choices.ElementAt(1).ReponseText;
                Choice2 = choices.ElementAt(1);

            }
            else
            {
                choice2Button.GetComponent<Image>().enabled = false;
                choice2Button.GetComponent<Button>().enabled = false;
                choice2Button.GetComponentInChildren<TextMeshProUGUI>().text = "";

            }

            if (choices.Count > 2)
            {
                choice3Button.GetComponent<Image>().enabled = true;
                choice3Button.GetComponent<Button>().enabled = true;
                choice3Button.GetComponentInChildren<TextMeshProUGUI>().text = eventInfo.PlayerResponses.ElementAt(2).ReponseText;
                Choice3 = choices.ElementAt(2);
            }
            else
            {
                choice3Button.GetComponent<Image>().enabled = false;
                choice3Button.GetComponent<Button>().enabled = false;
                choice3Button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }

        }
        catch
        {

        }


    }
    public void SelectButton(int Choice)
    {
        if (Choice == 1)
        {
            sendResponse(Choice1);
        }
        else if (Choice == 2)
        {
            sendResponse(Choice2);
        }
        else if (Choice == 3)
        {
            sendResponse(Choice3);
        }
        time.text = times[UnityEngine.Random.Range(0, times.Length)];


    }
    private void sendResponse(Response playerChoice)
    {
        if (playerChoice.NextSceneIndex != 0)
        {
            PlayerPrefs.SetInt("Build", playerChoice.NextSceneIndex);
            GameObject.Find("LevelChanger").GetComponent<LevelChanger>().FadeToLevel(3);
        }

        if (playerChoice.NextDay != null)
        {
            PlayerPrefs.SetString("Day", playerChoice.NextDay);
        }

        GameObject i = GameObject.Instantiate(ResponseTemplate);
        i.transform.localScale = new Vector3(63.3f, 63.3f, 1);
        i.transform.SetParent(Canvas, false);
        i.transform.position = new Vector3(5f, -2f, 0);
        GameObject b = GameObject.Instantiate(TextTemplate);

        b.transform.SetParent(i.transform);
        b.GetComponent<TextMeshProUGUI>().text = playerChoice.ReponseText;
        b.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3.3f, 0.42f);

        movePastMessage();
        gameObject.GetComponents<AudioSource>()[1].Play();

        choice1Button.GetComponent<Image>().enabled = false;
        choice1Button.GetComponent<Button>().enabled = false;
        choice1Button.GetComponentInChildren<TextMeshProUGUI>().text = "";

        choice2Button.GetComponent<Image>().enabled = false;
        choice2Button.GetComponent<Button>().enabled = false;
        choice2Button.GetComponentInChildren<TextMeshProUGUI>().text = "";

        choice3Button.GetComponent<Image>().enabled = false;
        choice3Button.GetComponent<Button>().enabled = false;
        choice3Button.GetComponentInChildren<TextMeshProUGUI>().text = "";

        StartCoroutine(delay(playerChoice.NextPrompt));
    }
    private void sendPrompt(Prompt prompt)
    {
        if (prompt.PromptText != "")
        {
            GameObject i = GameObject.Instantiate(PromptTemplate);
            i.transform.localScale = new Vector3(63.3f, 63.3f, 1);
            i.transform.SetParent(Canvas, false);
            i.transform.position = new Vector3(-5f, -2f, 0);
            GameObject b = GameObject.Instantiate(TextTemplate);

            b.transform.SetParent(i.transform);
            b.GetComponent<TextMeshProUGUI>().text = prompt.PromptText;
            b.GetComponent<RectTransform>().anchoredPosition = new Vector2(-3.4f, 0.076f);

            movePastMessage();
            gameObject.GetComponents<AudioSource>()[0].Play();
        }

        displayPlayerChoices(prompt);
    }
    private void movePastMessage()
    {
        foreach (GameObject message in GameObject.FindGameObjectsWithTag("Message"))
        {
            if (message.transform.localPosition.y > 150)
            {
                message.transform.position = new Vector3(message.transform.position.x, message.transform.position.y + 5f, message.transform.position.z);
            }
            else
            {
                message.transform.position = new Vector3(message.transform.position.x, message.transform.position.y + 0.75f, message.transform.position.z);
            }
        }
    }
    IEnumerator delay(Prompt prompt)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1, 4));
        sendPrompt(prompt);
    }


}
