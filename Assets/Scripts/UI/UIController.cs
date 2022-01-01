using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The manager script for the user interface components.
/// </summary>
public class UIController : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private Image titleImage;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private Text timerText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Animator outOfTimeAnimator;
    [SerializeField] private GameObject glass;
    [SerializeField] private GameObject powerSliderFill;

    [SerializeField] private CrosshairRaycast crosshair;
    [SerializeField] private ThrowBrick brickScript;


    [SerializeField] public Slider powerBarSlider;

    [SerializeField] private List<GameObject> sections = new List<GameObject>(); //The floor for each section
    [SerializeField] private int sectionIdx = 0; //What section the player is on
    // COUNT FROM 0 YOU WEIRDO

    [SerializeField] private float gameDuration = 6f; // how long to run timer
    [SerializeField] private float powerBarDuration = 5f; // how long for power up bar to fill up
    [SerializeField] private float powerUpDuration = 5f; //how long actual power up lasts
    private float timerValue;
    private float powerValue; //for filling up bar
    private float powerUpLeft; //for the actual power up

    private bool timerStarted = false; // is timer counting
    private bool timerStopped = false; // timer has reached 0
    private bool powerBarFilling = false;
    private bool powerBarFull = false;
    private bool powerUpActive = false;
    public bool powerupMode = false;

    private float startTime;
    private float elapsedTime;
    private float currentTime;

    private Vector3 scaleChange = new Vector3(1.8f, 1f, 1f);
    private Vector3 positionChange = new Vector3(430f, 0f, -430f);

    public Image powerFill;
    public Sprite powerBarInactive;
    public Sprite powerBarActive;

    private void Start()
    {
        // powerFill = GetComponent<Image>();
        startTimer();
        startPower();
        startTime = Time.time;
        currentTime = Time.time;
        timerSlider.maxValue = gameDuration;
        timerSlider.value = gameDuration;
        timerValue = gameDuration;
        powerValue = powerBarDuration;
        powerBarSlider.maxValue = powerBarDuration;
        powerBarSlider.value = 0;
    }

    private void Update()
    {
        elapsedTime = Time.time - startTime;
        if (timerStarted && !powerUpActive)
        {
            titleImage.enabled = false;

            timerValue -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timerValue / 60);
            int seconds = Mathf.FloorToInt(timerValue - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (timerValue <= 0)
            {
                timerStopped = true;
                //LoadScene("MenuScene");
                menuButton.SetActive(true);

                if (sectionIdx > 0)
                {
                    if (sections[sectionIdx - 1].GetComponent<Rigidbody>() != null)
                    {
                        sections[sectionIdx - 1].GetComponent<Rigidbody>().isKinematic = false;
                    }
                    foreach (Rigidbody rb in sections[sectionIdx - 1].GetComponentsInChildren<Rigidbody>())
                    {
                        rb.isKinematic = false;
                    }
                }
                Debug.Log(sectionIdx);
            }

            if (!timerStopped)
            {
                timerText.text = textTime;
                timerSlider.value = timerValue;
            }
        }

        if (powerBarSlider.value > 0)
        {

        }


        if (!powerupMode)
        {
            powerBarSlider.value += .2f * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && powerBarSlider.value > 0)
        {
            powerupMode = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || powerBarSlider.value <= 0 /*!powerBarFull /*&& !(Input.GetKey(KeyCode.LeftShift))*/)
        {
            powerupMode = false;

            glass.SetActive(false);
            powerFill.sprite = powerBarInactive;
            powerBarSlider.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (powerupMode)
        {
            glass.SetActive(true);
            powerBarSlider.transform.localScale = scaleChange;
            powerFill.sprite = powerBarActive;
            powerBarSlider.value -= Time.deltaTime;
            crosshair.SetVisible(true);
            if (crosshair.IsOnTarget() && Input.GetMouseButton(0))
            {
                brickScript.Throw();
            }
        } else
        {
            crosshair.SetVisible(false);
        }

    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(wait(sceneName));
    }

    public void reset()
    {
        if (sectionIdx > 0)
        {
            if (sections[sectionIdx - 1].GetComponent<Rigidbody>() != null)
            {
                sections[sectionIdx - 1].GetComponent<Rigidbody>().isKinematic = false;
            }
            foreach (Rigidbody rb in sections[sectionIdx - 1].GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = false;
            }
        }
        Debug.Log(sectionIdx);

        //timesUpText.text = "";
        timerStopped = false;

        timerValue = gameDuration;
        sectionIdx++;
    }

    IEnumerator wait(string sceneName)
    {
        outOfTimeAnimator.SetTrigger("GameOver");
        canvas.SetActive(false);
        yield return new WaitForSeconds(1);
        GetComponent<ChangeScene>().LoadScene(sceneName);
    }

    public void startTimer()
    {
        timerStarted = true;
    }

    public void startPower()
    {
        powerBarFilling = true;
    }

    public bool isTimerStopped()
    {
        return timerStopped;
    }
}
