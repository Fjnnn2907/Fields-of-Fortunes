using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PotentialManager : MonoBehaviour
{
    public static PotentialManager Instance;


    public int potential;
    public int Point = 0;
    public int Point1 = 0;
    private void Awake()
    {
        Instance = this;
    }
    public void SetPotential(int _potential)
    {
        potential += _potential;
    }
    public void Log()
    {
        Debug.Log("a"); 
    }
    public void GetPotential(int count)
    {
        if (potential <= 0) return;
        if (count == 1)
        {
            Debug.Log("a");
            potential -= count;
            Point++;
            PlayerAttack.Instance.Damege += 1;

        }
        else if (count == 2)
        {
            potential --;
            Point1++;
            PlayerManger.Instance.maxHealth += 200;
        }
        else if ( count == 3)
        {
            potential -= count;
            Point++;
            Skill.Instance.damage *= 2;
        }
        else if (count == 3)
        {
            potential -= count;
            Point++;
            Skill2.instance.damege *= 2;
        }

    }
}
