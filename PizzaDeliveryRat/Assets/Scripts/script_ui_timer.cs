using UnityEngine;
using UnityEngine.UI;

public class script_ui_timer : MonoBehaviour
{
    public Text timeText;
    private float gameTime = 0;
    private float startTime = 0;

    private bool timeDone = false;
    //public script_ui_mainmenu linkToMenuScript;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = Time.time- startTime;
        gameTime = 10 - gameTime;
        timeText.text = "Time:"+gameTime.ToString("0");

        if (gameTime <= 0){
            //linkToMenuScript.isFinished = true;
            timeDone = true;
        }
    }

    public bool getTimeDone() { return timeDone; }
}
