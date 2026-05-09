using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private bool isMuted = false;
    private float originalVolume = 1.0f;

    public TextMeshProUGUI muteButtonText; // Reference to the UI Text component

    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

    }

    // Update is called once per frame
    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }
    public void Toggle()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            AudioListener.volume = 0.0f;
            muteButtonText.text = "Unmute";
        }
        else
        {
            AudioListener.volume = 1.0f;
            muteButtonText.text = "Mute";
        }
    }

    // Toggle music on and off
    public void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            originalVolume = sounds[0].source.volume; // Assuming the first sound's volume is representative
            foreach (Sound s in sounds)
            {
                s.source.volume = 0.0f;
            }
        }
        else
        {
            foreach (Sound s in sounds)
            {
                s.source.volume = originalVolume;
            }
        }
    }
}
