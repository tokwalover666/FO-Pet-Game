using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundsManager : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    public TMP_Text bubbleText;
    public Button pokeButton; 

    private int clickCount = 0;
    private bool isSoundPlaying = false; 
    private bool isSadSoundPlayed = false; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();


        if (pokeButton != null)
        {
            pokeButton.onClick.AddListener(OnPokeButtonClick);
        }
        else
        {
            Debug.LogWarning("Poke button is not assigned!");
        }
    }

    private void PlayCurrentSong(string songName)
    {
        AudioClip clip = FindSongByName(songName);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            isSoundPlaying = true; 
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

    public void PlayFeedSound()
    {
        PlayCurrentSong("eat");
        StartCoroutine(ShowTemporaryText("yumm", 1, 3));
    }

    public void PlayBathSound()
    {
        PlayCurrentSong("bath");
        StartCoroutine(ShowTemporaryText("meoww coldd", 1, 3));
    }

    public void PlaySleepSound()
    {
        PlayCurrentSong("sleep");
        StartCoroutine(ShowTemporaryText("mimimimi", 1, 3));
    }

    private void PlaySadSound()
    {
        if (!isSadSoundPlayed)
        {
            PlayCurrentSong("sad");
            StartCoroutine(ShowTemporaryText("I'm sad meow", 1, 6));
            isSadSoundPlayed = true; 
        }
    }

    public void OnPokeButtonClick()
    {
        if (isSoundPlaying) return;

        clickCount++;
        Debug.Log($"Button clicked. Current click count: {clickCount}");

        if (clickCount == 2)
        {
            StartCoroutine(ShowTemporaryText("ouch!", 0, 3));
        }
        else if (clickCount == 3)
        {
            StartCoroutine(ShowTemporaryText("stop poking me!", 0, 5));
        }
        else if (clickCount == 5)
        {
            PlaySadSound();
            clickCount = 0; 
        }
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

    private IEnumerator ShowTemporaryText(string text, float delay, float duration)
    {
        yield return new WaitForSeconds(delay);
        bubbleText.text = text;
        yield return new WaitForSeconds(duration);
        bubbleText.text = "";
    }

    private IEnumerator ResetIsSoundPlaying(float duration)
    {
        pokeButton.interactable = false; 
        yield return new WaitForSeconds(duration);
        pokeButton.interactable = true; 
        isSoundPlaying = false; 
        isSadSoundPlayed = false;
    }
}
