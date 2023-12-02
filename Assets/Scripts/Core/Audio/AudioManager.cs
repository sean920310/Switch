using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [SerializeField]
    private AudioMixer m_audioMixer;

    public void SetMasterVolume(float volume)
    {
        m_audioMixer.SetFloat("MasterVol", volume);
    }

    public void SetMusicVolume(float volume)
    {
        m_audioMixer.SetFloat("MusicVol", volume);
    }

    public void SetEffectVolume(float volume)
    {
        m_audioMixer.SetFloat("EffectVol", volume);
    }
}
