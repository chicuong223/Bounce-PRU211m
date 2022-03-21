using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    Text lv1;
    Text lv2;
    Text lv3;
    Text lv4;
    // Start is called before the first frame update
    void Start()
    {
        lv1 = GameObject.Find("TextLevel1").GetComponent<Text>();
        lv2 = GameObject.Find("TextLevel2").GetComponent<Text>();
        lv3 = GameObject.Find("TextLevel3").GetComponent<Text>();
        lv4 = GameObject.Find("TextLevel4").GetComponent<Text>();

        lv1.text = $"Level 1\n{TimeSpan.FromSeconds(LoadLevel.times[0]).ToString("hh':'mm':'ss")}";
        lv2.text = $"Level 2\n{TimeSpan.FromSeconds(LoadLevel.times[1]).ToString("hh':'mm':'ss")}";
        lv3.text = $"Level 3\n{TimeSpan.FromSeconds(LoadLevel.times[2]).ToString("hh':'mm':'ss")}";
        lv4.text = $"Level 4\n{TimeSpan.FromSeconds(LoadLevel.times[3]).ToString("hh':'mm':'ss")}";
    }

    private void Awake()
    {

    }
}
