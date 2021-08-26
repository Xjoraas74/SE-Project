using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour, IPointerClickHandler
{
    public GameObject PausePanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GiveUp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}