using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public List<AudioClip> sfxSteps = new List<AudioClip>();
  public AudioClip sfxHalfHP;
  public AudioClip sfxLowHP;

  [Space]
  public AudioSource audioMovement;
  public AudioSource audioCollectibles;

  public void PlayingClip()
  {
    foreach (var clip in sfxSteps)
      if (!audioMovement.isPlaying)
      {
        audioMovement.clip = clip;
        audioMovement.Play();
      }
  }

  public void PlayHalfHP()
  {
    audioCollectibles.PlayOneShot(sfxHalfHP);
  }

  public void PlayLowHP()
  {
    audioCollectibles.PlayOneShot(sfxLowHP);
  }
}
