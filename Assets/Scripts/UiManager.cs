using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class UiManager : MonoBehaviour
{
    public GameObject PausePanel;
    public List<GameObject> AbilityOptions;
    public GameObject LevelUpPanel;
    public TextMeshProUGUI SurvivalTimeText, PausePanelLevel, KillCount;
    public TextMeshProUGUI LevelUpPanelLevel;
    public Image MpBar, HpBar;
    public Slider HpBarSlider;
    public Gradient HpBarGradient;
    public Subject Subject;

    private void LateUpdate()
    {
        int time = Mathf.FloorToInt(Time.timeSinceLevelLoad);

        SurvivalTimeText.SetText((time / 60).ToString("d2") + ":" + (time % 60).ToString("d2"));
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        PausePanelLevel.SetText("Level: " + Subject.Level);
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

    public void UpdateMpBar(float mpForCurrentLevel, float currentMp, float mpForNewLevel)
    {
        MpBar.fillAmount = (currentMp - mpForCurrentLevel) / (mpForNewLevel - mpForCurrentLevel);
    }

    public void UpdateHpBar(float hp, float hpMax)
    {
        HpBarSlider.maxValue = hpMax;
        HpBarSlider.value = hp;
        HpBar.color = HpBarGradient.Evaluate(HpBarSlider.normalizedValue);
    }

    public void LevelUp() {
        LevelUpPanel.SetActive(true);
        Time.timeScale = 0;
        LevelUpPanelLevel.SetText("Level: " + Subject.Level);
        var abilities = Subject.GetComponents<Ability>().Where(a => a.IsUpgradeable == true).ToList();
        for (int i = 0; i < AbilityOptions.Count; i++)
        {
            // choose a random ability
            var abilityInd = Random.Range(0, abilities.Count());
            var ability = abilities.ElementAt(abilityInd);
            abilities.RemoveAt(abilityInd);

            // fill the option data (also the button listener)
            var option = AbilityOptions[i];
            option.transform.Find("Name").GetComponent<TextMeshProUGUI>().SetText(ability.Name);
            option.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText(ability.Description);
            option.transform.Find("NewLevel").GetComponent<TextMeshProUGUI>().SetText("Lv " + (ability.Level + 1).ToString());
            var button = option.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { 
                ability.Upgrade();
                Time.timeScale = 1f;
                LevelUpPanel.SetActive(false);
            });
        }
    }
}
