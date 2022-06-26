using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private UnityEvent _pressedButton = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _pressedButton.Invoke();
        }
    }
}
