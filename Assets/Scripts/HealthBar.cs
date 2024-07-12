using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Slider feedBar;
    public Slider playBar;
    public Slider bathBar;
    public Slider sleepBar;

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

    private bool isShowingHungerText = false;
    private bool isShowingHappyText = false;
    private bool isShowingCleanText = false;
    private bool isShowingSleepText = false;

    private void Update()
    {
        hunger -= .1f * Time.deltaTime;
        happy -= .5f * Time.deltaTime;
        clean -= .15f * Time.deltaTime;
        sleep -= .01f * Time.deltaTime;

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
        feedBar.value = ratio;
        if (hunger < 50f && !isShowingHungerText)
        {
            StartCoroutine(ShowTemporaryText("hungrrry me ow", 1, 3, ref isShowingHungerText));
        }
    }

    private void UpdateHappyBar()
    {
        float ratio = happy / max;
        playBar.value = ratio;
        if (happy < 50f && !isShowingHappyText)
        {
            StartCoroutine(ShowTemporaryText("I'm sad!", 1, 3, ref isShowingHappyText));
        }
    }

    private void UpdateCleanBar()
    {
        float ratio = clean / max;
        bathBar.value = ratio;
        if (clean < 50f && !isShowingCleanText)
        {
            StartCoroutine(ShowTemporaryText("I'm dirty!", 1, 3, ref isShowingCleanText));
        }
    }

    private void UpdateSleepBar()
    {
        float ratio = sleep / max;
        sleepBar.value = ratio;
        if (sleep < 50f && !isShowingSleepText)
        {
            StartCoroutine(ShowTemporaryText("I'm sleepy!", 1, 3, ref isShowingSleepText));
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

    private IEnumerator ShowTemporaryText(string text, float delay, float duration, ref bool isShowingText)
    {
        isShowingText = true;
        yield return soundManager.ShowTemporaryText(text, delay, duration);
        isShowingText = false;
    }
}
