﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Horror_Test : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxis axes = RotationAxis.MouseX;
    public float minimunVert = -45.0f;
    public float maximumVert = 45.0f;
    public float sensHorizontal = 10.0f;
    public float sensVertical = 10.0f;
    public float _rotationX = 0;
    public float _rotationY = 0;
    // Update is called once per frame
    public void Start()
    {
     
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (axes == RotationAxis.MouseX)
            {

                transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
            }
            else if (axes == RotationAxis.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
                _rotationX = Mathf.Clamp(_rotationX, minimunVert, maximumVert);//Clamps the vertical angle 
            }
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

    }
}
