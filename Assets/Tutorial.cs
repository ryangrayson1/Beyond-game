using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * By Ryan Grayson
 */
public class Tutorial : MonoBehaviour
{
    [SerializeField] public GameObject tutorialPanel;

    [SerializeField] public GameObject blockingAutoRun;
    [SerializeField] public GameObject blockingJump;
    [SerializeField] public GameObject blockingSlide;
    [SerializeField] public GameObject blockingShoot;
    [SerializeField] public GameObject blockingSlow1;
    [SerializeField] public GameObject blockingSlow2;
    [SerializeField] public GameObject blockingExit;

    //public GameObject tutorialToMenu;

    public Text clickToContinue;
    public Text welcome;
    public int phase;

    // Start is called before the first frame update
    void Start()
    {
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialPanel.active){

            if (phase == 0){
                blockingExit.SetActive(false);
                blockingJump.SetActive(true);
                welcome.text = "Welcome to the Beyond Tutorial!";
                clickToContinue.text = "Space to continue!";
                if (Input.GetKeyDown(KeyCode.Space)){
                    phase = 1;
                }
            }

            else if (phase == 1){
                blockingExit.SetActive(true);
                welcome.text = "";
                clickToContinue.text = "Click to continue!";
                blockingAutoRun.SetActive(false);
                if (Input.GetMouseButtonDown(0)){
                    blockingAutoRun.SetActive(true);
                    phase = 2;
                }
            }

            else if (phase == 2){
                blockingExit.SetActive(true);
                welcome.text = "";
                clickToContinue.text = "";
                blockingSlide.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Q)){
                    blockingSlide.SetActive(true);
                    phase = 3;
                }
            }

            else if (phase == 3){
                blockingExit.SetActive(true);
                welcome.text = "";
                clickToContinue.text = "";
                blockingJump.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space)){
                    blockingJump.SetActive(true);
                    phase = 4;
                }
            }

            else if (phase == 4){
                blockingExit.SetActive(true);
                welcome.text = "";
                clickToContinue.text = "";
                blockingSlow1.SetActive(false);
                blockingSlow2.SetActive(false);
                if (Input.GetKeyDown(KeyCode.LeftShift)){
                    blockingSlow1.SetActive(true);
                    blockingSlow2.SetActive(true);
                    phase = 5;
                }
            }

            else if (phase == 5){
                blockingExit.SetActive(true);
                welcome.text = "Click to continue!";
                clickToContinue.text = "";
                blockingShoot.SetActive(false);
                if (Input.GetMouseButtonDown(0)){
                    blockingShoot.SetActive(true);
                    phase = 6;
                }
            }

            else if (phase == 6){
                blockingExit.SetActive(false);
                welcome.text = "You Are Ready!";
                blockingShoot.SetActive(true);
            }
        }
    }

    public void enableTutorial(){
        phase = 0;
        tutorialPanel.SetActive(true);
    }
    public void disableTutorial(){
        tutorialPanel.SetActive(false);
    }
}
