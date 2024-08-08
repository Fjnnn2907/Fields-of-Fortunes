using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public GameObject tele;
    public int KillEnemy;

    private void Update()
    {
        if(SpawnManager.Instance.count >= KillEnemy)
        {
            tele.SetActive(true);
        }
    }
}
