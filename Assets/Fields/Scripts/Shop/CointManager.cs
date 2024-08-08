using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CointManager : MonoBehaviour
{
    public static CointManager Instance;
    public int Coint = 0;
    public int CointDu;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Coint = 1000;
    }
    public void SetCoint(int coint)
    {
        Coint += coint;
    }
    
    public void GetCoint(int coint)
    {
        CointDu = coint;
        if (this.Coint < CointDu) return;
        Coint -= coint;
        if (Coint <= 0) Coint = 0;
    }

}
