using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public float FollowSpeed;
    public Transform target;
    public Vector2 Max;
    public Vector2 Min;
    // Update is called once per frame
    void LateUpdate()
    {
        if(this.transform.position != target.position)
        {
            Vector3 targetPositon = new Vector3(target.position.x, target.position.y, -10);

            targetPositon.x = Mathf.Clamp(targetPositon.x,Min.x,Max.x);

            targetPositon.y = Mathf.Clamp(targetPositon.y,Min.y,Max.y);

            transform.position = Vector3.Lerp(transform.position, targetPositon, FollowSpeed);
        }
    }    
}
