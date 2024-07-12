using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIMenuManager : MonoBehaviour
{
    public RectTransform mainMenu, settingsMenu, closetMenu, petProfileMenu;

    public float uiTransitionSpeed;
    public float scaleFactor = 1.2f; 
    public float popDuration = 0.2f;

    public HealthBar healthBar;

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

    public void PopButton(RectTransform button)
    {
        if (button == null)
        {
            Debug.LogWarning("Button is not assigned!");
            return;
        }
        button.DOKill();
        Vector3 originalScale = button.localScale;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(button.DOScale(button.localScale * scaleFactor, popDuration).SetEase(Ease.OutQuad));
        sequence.Append(button.DOScale(button.localScale, popDuration).SetEase(Ease.InQuad));
    }

    public void OnFeedButtonClick(RectTransform button)
    {
        PopButton(button);
        healthBar.IncreaseFeedBar();
    }

    public void OnPlayButtonClick(RectTransform button)
    {
        PopButton(button);
        healthBar.IncreasePlayBar();
    }

    public void OnBathButtonClick(RectTransform button)
    {
        PopButton(button);
        healthBar.IncreaseBathBar();
    }

    public void OnSleepButtonClick(RectTransform button)
    {
        PopButton(button);
        healthBar.IncreaseSleepBar();
    }

}
