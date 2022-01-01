using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public static bool death = false;
    public Image fadeBlack;
    public static float score = 0f;
    public float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        fadeBlack = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!death)
            score += Time.deltaTime;   

        if (death){
            t += Time.deltaTime;
            Debug.Log(t);

            if (t < 3){
                fadeBlack.color = new Color(0, 0, 0, t);
            }

            if (t >= 3){
                updates.justDied = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("MenuScene");
            }

        }
    }
}
