using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("SceneControl").GetComponent<UIController>().reset();
            gameObject.SetActive(false);
        }
    }
}
