using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image currentHunger;
    public Image currentHappy;
    public Image currentClean;
    public Image currentSleep;

    private float hunger = 100;
    private float happy = 100;
    private float clean = 100;
    private float sleep = 100;
    private float max = 100;

    public float feedIncrement = 40f;
    public float playIncrement = 50f;
    public float bathIncrement = 70f;
    public float sleepIncrement = 60f;

    public SoundsManager soundManager;

    private void Update()
    {
        hunger -= .11f * Time.deltaTime;
        happy -= .15f * Time.deltaTime;
        clean -= .115f * Time.deltaTime;
        sleep -= .10f * Time.deltaTime;

        if (hunger < 0) hunger = 0;
        if (happy < 0) happy = 0;
        if (clean < 0) clean = 0;
        if (sleep < 0) sleep = 0;

        UpdateHungerBar();
        UpdateHappyBar();
        UpdateCleanBar();
        UpdateSleepBar();
    }

    private void UpdateHungerBar()
    {
        float ratio = hunger / max;
        currentHunger.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (hunger <= 0.5f)
        {
            soundManager.ShowTemporaryText("I'm hungry!", 1, 3);
        }
    }

    private void UpdateHappyBar()
    {
        if (soundManager.clickCount >= 2)
        {
            happy = -1f;
        }
        float ratio = happy / max;
        currentHappy.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (ratio < 0.5f)
        {
            soundManager.ShowTemporaryText("I'm sad!", 1, 3);
        }

    }

    private void UpdateCleanBar()
    {
        float ratio = clean / max;
        currentClean.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (ratio < 0.5f)
        {
            soundManager.ShowTemporaryText("I'm dirty!", 1, 3);
        }
    }

    private void UpdateSleepBar()
    {
        float ratio = sleep / max;
        currentSleep.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (ratio < 0.5f)
        {
            soundManager.ShowTemporaryText("I'm sleepy!", 1, 3);
        }
    }

    public void IncreaseFeedBar()
    {
        hunger += feedIncrement;
        if (hunger > max) hunger = max;
        UpdateHungerBar();
    }

    public void IncreasePlayBar()
    {
        happy += playIncrement;
        if (happy > max) happy = max;
        UpdateHappyBar();
    }

    public void IncreaseBathBar()
    {
        clean += bathIncrement;
        if (clean > max) clean = max;
        UpdateCleanBar();
    }

    public void IncreaseSleepBar()
    {
        sleep += sleepIncrement;
        if (sleep > max) sleep = max;
        UpdateSleepBar();
    }
}