using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetting : MonoBehaviour
{
    public AudioMixer MixerAudio;

   public void SetMasterVol(float MasterVol)
    {
        Debug.Log(MasterVol);
        MixerAudio.SetFloat("MasVolMixer", MasterVol);
    }

    public void SetMusicVol(float MusicVol)
    {
        Debug.Log(MusicVol);
        MixerAudio.SetFloat("MusVolMixer", MusicVol);
    }

    public void SetSfxVol(float SfxVol)
    {
        Debug.Log(SfxVol);
        MixerAudio.SetFloat("SfxVolMixer", SfxVol);
    }

}
