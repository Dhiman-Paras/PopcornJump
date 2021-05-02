
using UnityEngine;
using UnityEngine.UI;
public class PlayMenuUIController : MonoBehaviour
{
   
    public Text scoreText;
    public Text totalScoreText;
    public Text msgText;
    public static string msg = "";

    public GameObject scoreMenuUI;
    
    public PlayerController playerScript;
    public GameController gameControllerScript;
   public Platform platformScript;
    void Start()
    {
        
    }

   public void PlayAgain() {
      //  isGameReset = true;
        playerScript.ResetPlayerPosition();
        gameControllerScript.ResetStartingPlatform();
        PlayerController.score = 0;
        msg = "";
    }
    public void Exit(){
        Application.Quit();
    }
    // Update is called once per frame
    void Update(){
        scoreText.text = "Score : "+PlayerController.score.ToString(); // displaying the score 
       totalScoreText.text= "Game Over\n\nTotal Score\n" + PlayerController.score.ToString(); // displaying the score
        msgText.text = msg;
        if (msg == "Game Over"){
            Time.timeScale = 0f;
            scoreMenuUI.SetActive(true);
        }
        else { scoreMenuUI.SetActive(false); Time.timeScale = 1f; }
    }
}
