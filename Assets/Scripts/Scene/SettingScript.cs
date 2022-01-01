using UnityEngine;
using UnityEngine.UI;

/**
 * By Ryan Grayson
 */
public class SettingScript : MonoBehaviour
{
    public Button playsettingsButton;
    public Button exitSettingsButton;

    public GameObject playScreen;
    public GameObject settingsScreen;

    private bool isPlayScreenActive;

    void Start()
    {
        isPlayScreenActive = true;
        playScreen.SetActive(isPlayScreenActive);
        settingsScreen.SetActive(!isPlayScreenActive);

        playsettingsButton.onClick.AddListener(swapCanvas);
        exitSettingsButton.onClick.AddListener(swapCanvas);
    }

    public void swapCanvas()
    {
        isPlayScreenActive = !isPlayScreenActive;
        playScreen.SetActive(isPlayScreenActive);
        settingsScreen.SetActive(!isPlayScreenActive);
    }
}
