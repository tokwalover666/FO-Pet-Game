using TMPro;
using UnityEngine;
using UnityEngine.UI; // For Button
using System.Collections;

public class SoundsManager : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    public TMP_Text bubbleText;
    public Button pokeButton; // Reference to the Poke button

    private int clickCount = 0;
    private bool isSoundPlaying = false; // Track if a sound is currently playing
    private bool isSadSoundPlayed = false; // Track if the sad sound has been played

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ensure pokeButton is assigned and has an onClick listener
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
            isSoundPlaying = true; // Set flag when sound starts playing
            StartCoroutine(ResetIsSoundPlaying(audioSource.clip.length)); // Reset flag after sound finishes
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
        if (!isSadSoundPlayed) // Check to ensure sad sound has not been played
        {
            PlayCurrentSong("sad");
            StartCoroutine(ShowTemporaryText("I'm sad meow", 1, 6));
            isSadSoundPlayed = true; // Mark that sad sound has been played
        }
    }

    public void OnPokeButtonClick()
    {
        if (isSoundPlaying) return; // Prevent clicks while sound is playing

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
            clickCount = 0; // Reset the counter after playing the sad sound
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
        pokeButton.interactable = false; // Disable the button
        yield return new WaitForSeconds(duration); // Wait for the duration of the sound
        pokeButton.interactable = true; // Re-enable the button
        isSoundPlaying = false; // Reset the flag
        isSadSoundPlayed = false; // Reset the flag to allow sound to be played again
    }
}
