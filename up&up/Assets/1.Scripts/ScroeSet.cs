using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScroeSet : MonoBehaviour
{

    public Text scoreText;
    public Text highText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + GameManager.score;
        highText.text = "High:" + GameManager.high;
    }
}
