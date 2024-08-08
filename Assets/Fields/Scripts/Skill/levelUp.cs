using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class levelUp : MonoBehaviour
{
    private Transform tager;
    private void Start()
    {
        tager = GameObject.FindGameObjectWithTag("effect").transform;
        Destroy(this.gameObject, 0.8f);
    }
    private void FixedUpdate()
    {
        this.transform.position = tager.transform.position;
    }

}
