using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Button button))
        {
            Door.OnButtonPress.Invoke();
        }

        if (other.TryGetComponent(out SecurityZone securityZone))
        {
            Siren.OnSecurityZoneEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out SecurityZone securityZone))
        {
            Siren.OnSecurityZoneExit.Invoke();
        }
    }
}
