using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIMenuManager : MonoBehaviour
{
    public RectTransform mainMenu, settingsMenu, closetMenu, petProfileMenu;
    public float uiTransitionSpeed;

    public void ShowClosetMenu()
    {
        closetMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        mainMenu.DOAnchorPos(new Vector2(1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }
    public void ShowMainMenuFromCloset()
    {
        mainMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        closetMenu.DOAnchorPos(new Vector2(1130, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }
    public void ShowSettingsMenuFromCloset()
    {
        settingsMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        closetMenu.DOAnchorPos(new Vector2(-1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }
    public void ShowPetProfile()
    {
        petProfileMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        mainMenu.DOAnchorPos(new Vector2(2261, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }

    public void ShowMainMenuFromPetProfile()
    {
        mainMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        petProfileMenu.DOAnchorPos(new Vector2(2261, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }

    public void ShowSettingsMenu()
    {
        settingsMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        mainMenu.DOAnchorPos(new Vector2(-1100, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
    }
    public void ShowMainMenuFromSettings()
    {
        mainMenu.DOAnchorPos(Vector2.zero, uiTransitionSpeed, true).SetEase(Ease.InOutElastic);
        settingsMenu.DOAnchorPos(new Vector2(-1130, 0), uiTransitionSpeed, true).SetEase(Ease.Linear);
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
