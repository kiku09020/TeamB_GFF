using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FishAudio : MonoBehaviour
{
    /* 値 */
    [SerializeField] AudioSource source;

    [Header("Clips")]
    [SerializeField] List<AudioClip> eatenSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> waterSounds = new List<AudioClip>();

	/* コンポーネント取得用 */


	//-------------------------------------------------------------------
	public void PlayEatenAudio(Fish.FishType type)
	{
        AudioClip clip = eatenSounds[(int)type];
        source.PlayOneShot(clip);
	}

    public void PlayWaterAudio()
    {
        int rand = Random.Range(0, waterSounds.Count);
        AudioClip clip = waterSounds[rand];

        source.PlayOneShot(clip);
	}
}
