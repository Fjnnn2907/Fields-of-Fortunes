using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseManager : MonoBehaviour
{
    public GameObject Slot;
    public GameObject Coint;
    public GameObject Equipment;
    public GameObject Discription;
    private void Start()
    {
        Slot.SetActive(true);
        Discription.SetActive(true);
        Equipment.SetActive(false);

    }
    public void OpenClose(bool isOpen)
    {
        if(isOpen)
        {
            Slot.SetActive(true);
            Coint.SetActive(true);
            Discription.SetActive(true);
            Equipment.SetActive(false);
        }
        else
        {
            Slot.SetActive(false);
            Coint.SetActive(false);
            Discription.SetActive(false);
            Equipment.SetActive(true);
        }
    }
}
