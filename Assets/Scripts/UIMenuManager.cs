using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIMenuManager : MonoBehaviour
{
    public RectTransform mainMenu, settingsMenu, closetMenu;
    public CanvasGroup settingsCanvasGroup;
    public float uiTransitionSpeed;


    void Start()
    {
        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    void Update()
    {

    }

    public void ShowClosetMenu()
    {
        closetMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        mainMenu.DOAnchorPos(new Vector2(-1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }

    public void ShowMainMenu()
    {
        mainMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        settingsMenu.DOAnchorPos(new Vector2(-1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }

    public void ShowSettingsMenu()
    {
        settingsMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        mainMenu.DOAnchorPos(new Vector2(-1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }

/*    public void ShowSettings()
    {
        settingsMenu.SetAsLastSibling();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(settingsMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true));
        sequence.Append(settingsMenu.DOScale(Vector2.zero, 0));
        sequence.AppendInterval(0.1f);
        sequence.Append(settingsMenu.DOScale(Vector2.one, 0.2f)).SetEase(Ease.Linear);

        settingsCanvasGroup.DOFade(1, uiTransitionSpeed);
        settingsCanvasGroup.interactable = true;
        settingsCanvasGroup.blocksRaycasts = true;

        Debug.Log($"Before animation: {settingsMenu.anchoredPosition} / {settingsMenu.localScale}");
        Debug.Log($"After animation: {settingsMenu.anchoredPosition} / {settingsMenu.localScale}");
    }

    public void BackSettings()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(settingsMenu.DOScale(Vector2.zero, 0.1f));
        sequence.AppendInterval(0.1f);
        sequence.Append(settingsMenu.DOAnchorPos(new Vector2(-1100, 0), 0, true));
        sequence.Append(settingsMenu.DOScale(Vector2.one, 0)).SetEase(Ease.Linear);
    }*/
}
