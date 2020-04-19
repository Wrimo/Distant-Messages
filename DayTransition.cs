using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayTransition : MonoBehaviour
{
   public TextMeshProUGUI day;
    void Start()
    {
        day.text = PlayerPrefs.GetString("Day");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
