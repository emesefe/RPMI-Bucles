using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Movement movementScript;

    private void Start()
    {
        movementScript = FindObjectOfType<Movement>();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Fhinn")
        {
            movementScript.checkpointPosition = transform.position;
        }
    }
}
