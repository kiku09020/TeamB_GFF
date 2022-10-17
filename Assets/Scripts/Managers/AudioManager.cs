using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [Header("AudioSource")]
    [SerializeField] List<AudioSource> AudSrcs;

    [Header("AudioClip")]
    [SerializeField] List<AudioClip> clps_BGM;
    [SerializeField] List<AudioClip> clps_SE_Cat;
    [SerializeField] List<AudioClip> clps_SE_Fish;
    [SerializeField] List<AudioClip> clps_SE_UI;
    List<List<AudioClip>> clpLists;

    //-------------------------------------------------------------------
    void Start()
    {
        // List<List<AudioClip>>にList<AudioClip>を格納
        clpLists = new List<List<AudioClip>>() { clps_BGM, clps_SE_Cat, clps_SE_Fish, clps_SE_UI };

        // BGM再生
        PlayBGM(AudioEnum.BGM.bgm1, true);
    }

    //-------------------------------------------------------------------
    // BGM再生
    public void PlayBGM(AudioEnum.BGM bgm, bool loop)
    {
        AudioSource audSrc = AudSrcs[(int)AudioEnum.AudSrc.BGM];

        // ループの有無
        audSrc.loop = (loop) ? true : false;

        // クリップ指定
        audSrc.clip = clps_BGM[(int)bgm];

        // 再生
        audSrc.Play();
    }

    // SE再生
    public void PlaySE(AudioEnum.AudSrc audSrcType, int se)
    {
        AudioSource audSrc = AudSrcs[(int)audSrcType];         // AudioSource
        AudioClip clip = clpLists[(int)audSrcType][se];    // AudioClipをclpListから参照する

        audSrc.PlayOneShot(clip);
    }

    //-------------------------------------------------------------------
    // 音声の一時停止(AudioSource指定)
    public void PauseAudio(bool pause, AudioEnum.AudSrc audSrc)
    {
        // 一時停止
        if (pause) {
            AudSrcs[(int)audSrc].Pause();
        }

        // 音声再開
        else {
            AudSrcs[(int)audSrc].UnPause();
        }
    }

    // 音声一時停止(全てのAudioSourceをまとめて一時停止)
    public void PauseAudio(bool pause)
    {
        // 一時停止
        if (pause) {
            for (int i = 0; i < AudSrcs.Count; i++) {
                AudSrcs[i].Pause();
            }
        }

        // 音声再開
        else {
            for (int i = 0; i < AudSrcs.Count; i++) {
                AudSrcs[i].UnPause();
            }
        }
    }
}
