using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePlayer : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = transform.position;
    }
}
