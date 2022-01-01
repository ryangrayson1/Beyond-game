using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Animator optionalTransition = null;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(TransitionToScene(sceneName));
    }

    IEnumerator TransitionToScene(string sceneName)
    {
        if (optionalTransition != null)
        {
            yield return new WaitForSeconds(3);
            optionalTransition.SetTrigger("GameOver");
        }
        SceneManager.LoadScene(sceneName);
    }
}
