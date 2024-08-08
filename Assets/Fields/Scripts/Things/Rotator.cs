using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] 
    private float rotateSpeed;

    [SerializeField] 
    private Vector2 rotationDirection;

    private void Start()
    {
        rotationDirection = new Vector2();
    }

    private void Update()
    {
        transform.Rotate(rotationDirection * rotateSpeed * Time.deltaTime);
    }
}