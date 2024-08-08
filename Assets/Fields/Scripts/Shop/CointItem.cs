using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CointManager.Instance.SetCoint(10);
            Destroy(this.gameObject);
        }       
    }
}
