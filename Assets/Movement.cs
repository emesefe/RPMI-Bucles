using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 checkpointPosition;
    private void Update()
    {
        transform.Translate(Vector3.right * 1 * Input.GetAxis("Horizontal") * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        transform.position = checkpointPosition;
    }
}
