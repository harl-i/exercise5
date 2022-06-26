using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    public static UnityEvent OnSecurityZoneEnter = new UnityEvent();
    public static UnityEvent OnSecurityZoneExit = new UnityEvent();

    private AudioSource _audioSource;
    private Coroutine _volumeToMax;
    private Coroutine _volumeToMin;
    private float _volumeStep = 0.03f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _volumeShutdownThreshold = 0.02f;

    private void Awake()
    {
        OnSecurityZoneEnter.AddListener(PlaySiren);
        OnSecurityZoneExit.AddListener(StopSiren);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void PlaySiren()
    {
        if (_volumeToMin != null)
        {
            StopCoroutine(_volumeToMin);
        }

        _audioSource.Play();
        _volumeToMax = StartCoroutine(VolumeToMax());
    }

    private void StopSiren()
    {
        if (_volumeToMax != null)
        {
            StopCoroutine(_volumeToMax);
        }

        _volumeToMin = StartCoroutine(VolumeToMin());
    }

    private IEnumerator VolumeToMax()
    {
        while (_audioSource.volume != 1)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeStep);
            yield return null;
        }
    }

    private IEnumerator VolumeToMin()
    {
        while (_audioSource.volume >= 0.02)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _volumeStep);
            yield return null; 
        }

        yield return new WaitUntil(() => _audioSource.volume <= _volumeShutdownThreshold);
        _audioSource.Stop();
    }
}
