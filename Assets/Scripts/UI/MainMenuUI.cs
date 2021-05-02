using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject playMenuUI;
    private void Awake(){
        Time.timeScale = 0f;
    }
    public void Play() {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        playMenuUI.SetActive(true);
    }
}
