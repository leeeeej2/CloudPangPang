using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Slider bgmVol;
    public Slider sfxVol;

    static bool isPlaying = false;

    [Header("Sound application")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("BGM player")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("sfx player")]
    [SerializeField] AudioSource[] sfxPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        //bgmPlayer.volume = 1f;

        bgmPlayer = GetComponent<AudioSource>();

        if (isPlaying)//bgmPlayer.isPlaying
        {
            return;
        }
        else
        {
            isPlaying = true;
            instance = this;
            bgmPlayer.volume = 0.5f;
            PlayBGM();
            DontDestroyOnLoad(transform.gameObject);
        }


    }

    void Start()
    {
        //instance = this;
        //bgmPlayer.volume = bgmVol.value;
        //PlayBGM();
    }

    private void Update()
    {
           bgmPlayer.volume = MoveScene.soundVolumeControl;
    }

    public void PlaySfx(string nameSound)
    {
        for(int i = 0; i < sfxSounds.Length; i++)
        {
            if(nameSound == sfxSounds[i].soundName)
            {
                for(int j = 0; j < sfxPlayer.Length; j++)
                {
                    if(!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].volume = MoveScene.soundVolumeControl;
                        sfxPlayer[j].clip = sfxSounds[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("All sfxPlayer is using!");
                return;
            }
        }
        Debug.Log("There is no sfxSound that matched with soundname");
    }

    public void PlayBGM()
    {
        bgmPlayer.clip = bgmSounds[0].clip;
        bgmPlayer.Play();
    }

    public void SetBGMVolume(float slider)
    {
        Debug.Log("volume is " + slider);
        bgmPlayer.volume = slider;
        //bgmVol.value = slider;
    }

    public void SetSFXVolume(float slider)
    {
        //sfxvo
    }
}
