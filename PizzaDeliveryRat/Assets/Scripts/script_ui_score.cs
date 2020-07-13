using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_ui_score : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void update(float score){
        Debug.Log("Score Change = " + score);
        scoreText.text = "Score: " + score.ToString();
    }
}
