using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance {  get; private set; }
    public float speed;
    public bool isCastingSkill = false;

    private void Awake()
    {
        Instance = this;
        
    }
    public void MoveUp()
    {
        if (isCastingSkill) return;
        this.transform.position = Vector2.MoveTowards(transform.position, 
            (Vector2)transform.position + new Vector2(0,Vector2.up.y * speed), speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        if (isCastingSkill) return;
        this.transform.position = Vector2.MoveTowards(transform.position, 
            (Vector2) transform.position+ new Vector2(0,Vector2.down.y * speed), speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        if (isCastingSkill) return;
        this.transform.position = Vector2.MoveTowards(transform.position, 
            (Vector2)transform.position + new Vector2(Vector2.right.x * speed,0).normalized, speed*Time.deltaTime);
        transform.localScale = new Vector3(-1,1,1);
    }

    public void MoveLeft()
    {
        if (isCastingSkill) return;
        this.transform.position = Vector2.MoveTowards(transform.position,
            (Vector2)transform.position + new Vector2(Vector2.left.x * speed, 0).normalized, speed*Time.deltaTime);
        transform.localScale = new Vector3(1, 1, 1);
    }


}
