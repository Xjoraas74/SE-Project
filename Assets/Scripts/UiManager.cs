using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject PausePanel; 
    public Transform MpBar;
    public TextMeshProUGUI SurvivalTimeText, Level, KillCount;

    private void LateUpdate()
    {
        int time = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        Vector3 mpBarSize = MpBar.localScale;

        SurvivalTimeText.SetText((time / 60).ToString("d2") + ":" + (time % 60).ToString("d2"));
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        Level.SetText("Level: " + Subject.Level);
        KillCount.SetText("Kill count: " + Subject.KillCount);
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
