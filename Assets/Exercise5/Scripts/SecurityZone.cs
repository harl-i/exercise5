using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecurityZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _enteredZone;
    [SerializeField] private UnityEvent _leftZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _enteredZone.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _leftZone.Invoke();
        }
    }
}
