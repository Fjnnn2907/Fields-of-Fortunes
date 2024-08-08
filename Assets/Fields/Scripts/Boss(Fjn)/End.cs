using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject end;

    private void Update()
    {
        if(BossFin.instance.hp <= 0)
        {
            end.SetActive(true);
        }
    }
}
