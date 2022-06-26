using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        EventManager.OnSecurityZoneEnter.AddListener(PlaySiren);
        EventManager.OnSecurityZoneExit.AddListener(StopSiren);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void PlaySiren()
    {
        _audioSource.Play();
        StartCoroutine(VolumeToMax());
    }

    private void StopSiren()
    {
        _audioSource.Stop();
        _audioSource.volume = 0;
    }

    private IEnumerator VolumeToMax()
    {
        while (_audioSource.volume != 1)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, 0.01f);

            yield return null;
        }
    }
}
