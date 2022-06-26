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
        StartCoroutine(VolumeToMin());
    }

    private IEnumerator VolumeToMax()
    {
        while (_audioSource.volume != 1)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, 0.01f);
            yield return null;
        }
    }

    private IEnumerator VolumeToMin()
    {
        while (_audioSource.volume >= 0.02)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, 0.01f);
            yield return null; 
        }

        yield return new WaitUntil(() => _audioSource.volume <= 0.02);
        _audioSource.Stop();
    }
}
