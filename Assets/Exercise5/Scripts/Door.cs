using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float _targetDoorLift = 5f;
    private float _liftStep = 0.05f;

    public void OpenDoor()
    {
        StartCoroutine(LiftDoor());
    }

    private IEnumerator LiftDoor()
    {
        for (int i = 0; transform.position.y < _targetDoorLift; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + _liftStep, transform.position.z);
            yield return null;
        }
    }
}
