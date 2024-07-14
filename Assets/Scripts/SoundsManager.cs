using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SoundsManager : MonoBehaviour
{
    public GameObject bubble;
    public AudioClip[] songs;
    public TMP_Text bubbleText;
    public Button[] additionalButtons; 
    public string backgroundMusicName;
    public AnimationManager animationManager;

    public Slider soundSlider;
    public Slider bgmSlider;

    private AudioSource audioSource;
    private AudioSource bgmAudioSource;
    public int clickCount = 0;

    private void Start()
    {
        bubble.SetActive(false);

        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            audioSource = audioSources[0];
            bgmAudioSource = audioSources[1];
        }
        else
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            bgmAudioSource = gameObject.AddComponent<AudioSource>();
        }

        PlayBackgroundMusic(backgroundMusicName);

        if (soundSlider != null)
        {
            soundSlider.value = audioSource.volume;
            soundSlider.onValueChanged.AddListener(SetSoundVolume);
        }
        if (bgmSlider != null)
        {
            bgmSlider.value = bgmAudioSource.volume;
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        }
    }

    private void PlayBackgroundMusic(string songName)
    {
        AudioClip clip = FindSongByName(songName);
        if (clip != null)
        {
            bgmAudioSource.clip = clip;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }
        else
        {
            Debug.LogWarning($"Background music with name '{songName}' not found.");
        }
    }

    private void PlayCurrentSong(string songName)
    {
        AudioClip clip = FindSongByName(songName);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.loop = false;
            audioSource.Play();
            StartCoroutine(ResetIsSoundPlaying(audioSource.clip.length));
        }
        else
        {
            Debug.LogWarning($"Song with name '{songName}' not found.");
        }
    }

    public void ButtonClickSound()
    {
        PlayCurrentSong("btn_click");
    }

    public void Button2ClickSound()
    {
        PlayCurrentSong("btn_click2");
    }

    public void PlayFeedSound()
    {
        PlayCurrentSong("eat");
        animationManager.PlayFeedAnimation();
        StartCoroutine(ShowTemporaryText("yumm", 1, 3));
    }

    public void PlayPlaySound()
    {
        PlayCurrentSong("play");
        animationManager.PlayPlayAnimation();
        StartCoroutine(ShowTemporaryText("purrr", 1, 3));
    }

    public void PlayBathSound()
    {
        PlayCurrentSong("bath");
        animationManager.PlayBathAnimation();
        StartCoroutine(ShowTemporaryText("meoww coldd", 1, 3));
    }

    public void PlaySleepSound()
    {
        PlayCurrentSong("sleep");
        animationManager.PlaySleepAnimation();
        StartCoroutine(ShowTemporaryText("mimimimi", 1, 3));
    }

    private AudioClip FindSongByName(string songName)
    {
        foreach (AudioClip song in songs)
        {
            if (song.name == songName)
            {
                return song;
            }
        }
        return null;
    }

    public IEnumerator ShowTemporaryText(string text, float delay, float duration)
    {
        yield return new WaitForSeconds(delay);
        bubble.SetActive(true);
        bubbleText.text = text;
        yield return new WaitForSeconds(duration);
        bubbleText.text = "";
        bubble.SetActive(false);
    }

    private IEnumerator ResetIsSoundPlaying(float duration)
    {
        DisableButtons(true);
        yield return new WaitForSeconds(duration);
        DisableButtons(false);
    }

    private void DisableButtons(bool disable)
    {
        foreach (Button button in additionalButtons)
        {
            if (button != null)
            {
                button.interactable = !disable;
            }
        }
    }

    public void SetSoundVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public void SetBGMVolume(float volume)
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.volume = volume;
        }
    }
}
