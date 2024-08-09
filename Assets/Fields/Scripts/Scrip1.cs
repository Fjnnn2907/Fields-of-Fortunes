using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrip1 : MonoBehaviour
{
    public GameObject game;
    private void Awake()
    {
        game = GameObject.Find("GameSession");
        Destroy(gameObject);
    }

}
