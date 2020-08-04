using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_ui_score : MonoBehaviour
{
    public Text scoreText;

    /// <summary>
    /// holds scoreText in UI
    /// </summary>
    public GameObject scoreObject;  
    private float scoreTextX = 0.0f; //This variable is used to update the Screen position of scoreText in Start()
    
    // Start is called before the first frame update
    void Start(){

        /*CODEBLOCK FOR SCORE PLACEMENT ~ varun(Cashmere)
         * scoreTextX is obtained as the difference between the Screen.width and 5% of Screen.width.
              > This means that the text will be placed dynamically at the very top-right
              > The Y position for height is arbitrarily set to 40.0f. Change as needed.
        */
        scoreTextX = Screen.width - 0.05f * (Screen.width);
        Vector3 newScoreTextPos = new Vector3(scoreTextX, Screen.height - 40.0f, 0.0f); 
        scoreObject.transform.position = newScoreTextPos;
    }

    // Update is called once per frame
    void Update(){
    }

    /// <summary>
    /// changes score text to given number
    /// score: new score to display
    /// </summary>
    /// <param name="score"></param>
    public void update(float score){

         
        //Debug.Log("Score Change = " + score);
        scoreText.text = "Score: " + score.ToString();
    }
}
