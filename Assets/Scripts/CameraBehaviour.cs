using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // store the distance between the main camer and player
    public Vector3 camOffset = new Vector3(2f, 0f, 5f);


    
    // hold the player's transform info: position, rotation, and scale
    [SerializeField] private Transform target;

    float rotationY;

    private void Update()
    {
        rotationY += Input.GetAxis("Horizontal");

        transform.position = target.position - Quaternion.Euler(0, 45, 0) * camOffset;
        this.transform.LookAt(target);
    }
}

