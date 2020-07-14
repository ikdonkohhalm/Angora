using UnityEngine;
using UnityEngine.UI;

public class script_ui_timer : MonoBehaviour
{
    public Text timeText;
    private float gameTime = 0;
    private float startTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = Time.time- startTime;
        timeText.text = "Time:"+gameTime.ToString("0");
    }
}
