using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider MasterVolume;
    public Slider FXVolume;
    public Toggle Mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionPanel;


    private void Awake()
    {
        FXVolume.onValueChanged.AddListener(ChangeVolumeFX);
        MasterVolume.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("DarkLight");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetMute()
    {
        mixer.GetFloat("VolMaster", out lastVolume);
        if (Mute.isOn)
        {
            mixer.SetFloat("VolMaster", -80);
        }
        else
        {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }
    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
}
