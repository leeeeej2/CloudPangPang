using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Sound application")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("BGM player")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("sfx player")]
    [SerializeField] AudioSource[] sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayBGM();
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
}
