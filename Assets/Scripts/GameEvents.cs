using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEvents : MonoBehaviour
{

    //Represents a collection of functiosn that can be triggered.
    

    [SerializeField]
    // represents p1 score
    private TMP_Text P1;

    [SerializeField]
    //represents p2 score.
     private TMP_Text P2;

     public TMP_Text winMessage;


     public int WinScore;


     public Canvas Menu;

     public Canvas GameUI;


    //Continously checks the scores to determine whether the game is over. 
     void CheckWin() {

         if (P1.text.Equals(WinScore.ToString())) {

             triggerWin(1);
         } 

         if (P2.text.Equals(WinScore.ToString())) {

             triggerWin(2);
         } 
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
    }

    // Triggers an end state when 
    void triggerWin(int playerWin) {

        if (playerWin == 1) {
            winMessage.SetText("Player 1 Wins");
        }

        if (playerWin == 2) {

            winMessage.SetText("Player 2 Wins");

        }

        GameUI.gameObject.SetActive(false);
        
        Menu.gameObject.SetActive(true);
        
    }


    public void Reload() {

        SceneManager.LoadScene("Game");

    }

    public void Exit() {

        Application.Quit();
    }
}
