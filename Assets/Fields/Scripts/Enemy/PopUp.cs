using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] float timeDestroy = 1;
    private void Start()
    {
        Destroy(gameObject,timeDestroy);
    }
}
