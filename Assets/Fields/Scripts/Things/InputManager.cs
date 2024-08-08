using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;
    private GameObject plants;

    void Update()
    {
        InputMovement();
    }
    
    public void InputMovement()
    {
        if(Input.GetKey(KeyCode.W))
            player.GetComponent<Movement>().MoveUp();
        if(Input.GetKey(KeyCode.S))
            player.GetComponent<Movement>().MoveDown();
        if(Input.GetKey(KeyCode.D))
            player.GetComponent<Movement>().MoveRight();
        if(Input.GetKey(KeyCode.A))
            player.GetComponent<Movement>().MoveLeft();
    }
}
