using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{
    public GameObject PausePanel;
    public TextMeshProUGUI SurvivalTimeText, Level, KillCount;
    public Image MpBar, HpBar;
    public Slider HpBarSlider;
    public Gradient HpBarGradient;

    private void LateUpdate()
    {
        int time = Mathf.FloorToInt(Time.timeSinceLevelLoad);

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

    public void UpdateMpBar(int currentMp, int mpForLevel)
    {
        MpBar.fillAmount = (float)(currentMp % mpForLevel) / mpForLevel;
    }

    public void UpdateHpBar(int hp, int hpMax)
    {
        HpBarSlider.maxValue = hpMax;
        HpBarSlider.value = hp;
        HpBar.color = HpBarGradient.Evaluate(HpBarSlider.normalizedValue);
    }
}
