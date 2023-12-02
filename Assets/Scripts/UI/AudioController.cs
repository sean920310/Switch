using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public void UpdateMasterVolume(Single volume)
    {
        AudioManager.Instance.SetMasterVolume(volume);
    }

    public void UpdateMusicVolume(Single volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }

    public void UpdateEffectVolume(Single volume)
    {
        AudioManager.Instance.SetEffectVolume(volume);
    }
}
