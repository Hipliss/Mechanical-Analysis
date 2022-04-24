using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger_footsteps : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioClip[] clipArray;

    public float pitchMin, pitchMax, volumeMin, volumeMax;

    private int clipIndex;

    public void PlayRoundRobin()
    {
        effectSource.pitch = Random.Range(pitchMin, pitchMax);
        effectSource.volume = Random.Range(volumeMin, volumeMax);

        if (clipIndex < clipArray.Length)
        {
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }
        else
        {
            clipIndex = 0;
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }
    }

    public void PlayRandom()
    {
        effectSource.pitch = Random.Range(pitchMin, pitchMax);
        effectSource.volume = Random.Range(volumeMin, volumeMax);
        clipIndex = RepeatCheck(clipIndex, clipArray.Length);
        effectSource.PlayOneShot(clipArray[clipIndex]);
    }

    int RepeatCheck(int previousIndex, int range)
    {
        int index = Random.Range(0, range);

        while (index == previousIndex)
        {
            index = Random.Range(0, range);
        }
        return index;
    }

}
