using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnButtonPress = new UnityEvent();
    public static UnityEvent OnSecurityZoneEnter = new UnityEvent();
    public static UnityEvent OnSecurityZoneExit = new UnityEvent();


    public static void SendButtonPress()
    {
        OnButtonPress.Invoke();
    }

    public static void SendSecurityZoneEnter()
    {
        OnSecurityZoneEnter.Invoke();
    }

    public static void SendSecurityZoneExit()
    {
        OnSecurityZoneExit.Invoke();
    }
}
