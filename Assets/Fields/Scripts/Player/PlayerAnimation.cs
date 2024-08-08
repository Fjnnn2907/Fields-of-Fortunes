using System.Collections;
using UnityEngine;
using static PlayerSkill;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;
    public Animator anim;

    private bool isUsingSkill = false; // Thêm biến này
    private bool isRun = true;
    private bool isSkill = true;

    private void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isUsingSkill) 
        {
            CreateAnimation();
        }
    }

    public void Skill1Aim()
    {
        isUsingSkill = true;
        anim.SetTrigger("skill1");
        anim.speed = 1.5f;
    }
    public void SkillAnim()
    {
        if (isSkill)
        {
            anim.SetTrigger("skill");
            anim.speed = 2;
            StartCoroutine(CountDown());           
        }
        
    }
    public void EndUsingSkill()
    {
        isUsingSkill = false;
    }

    public void CreateAnimation()
    {
        isRun = Mathf.Sqrt(Input.GetAxisRaw("Horizontal")) != 0 || Mathf.Sqrt(Input.GetAxisRaw("Vertical")) != 0;

        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("attack");
            anim.speed = 2;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetTrigger("skill");
            anim.speed = 2;
        }

        anim.SetBool("isRuning", isRun);
    }
    IEnumerator CountDown()
    {
        isSkill = false;
        yield return new WaitForSeconds(4);
        isSkill = true;
    }
}
