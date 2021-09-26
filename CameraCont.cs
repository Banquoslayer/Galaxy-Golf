using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    float inputX;

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        if (inputX != 0) rotate();
    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0f, inputX * Time.deltaTime, 0f));
    }
}
