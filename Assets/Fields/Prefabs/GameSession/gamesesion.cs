using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamesesion : MonoBehaviour
{
    private void Awake()
    {
        int numbersession = FindObjectsOfType<gamesesion>().Length;
        if (numbersession > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

    }
}
