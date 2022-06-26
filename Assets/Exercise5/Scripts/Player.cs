using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Button button))
        {
            EventManager.SendButtonPress();
        }

        if (other.TryGetComponent(out SecurityZone securityZone))
        {
            EventManager.SendSecurityZoneEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out SecurityZone securityZone))
        {
            EventManager.SendSecurityZoneExit();
        }
    }
}
