using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public GameObject isShop;
    public GameObject iconShop;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    private bool isOpened = true;
    private Transform buy;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        buy = GameObject.Find("PLAYER").transform;
        isOpened = false;
    }

    private void Update()
    {
        this.transform.position = buy.transform.position;
    }


    public void Open()
    {
        if (!isOpened)
        {
            isShop.SetActive(true);
            iconShop.SetActive(false);
            isOpened = true;
        }
    }
    public void Close()
    {
        if (isOpened)
        {
            isShop.SetActive(false);
            iconShop.SetActive(true);
            isOpened = false;
        }
    }

    public void BuyItem(int count)
    {
        if (CointManager.Instance.Coint <= 0)
            return;
        if (CointManager.Instance.CointDu > CointManager.Instance.Coint)
            return;
        if (count == 1)
        {
            CointManager.Instance.GetCoint(100);
            Instantiate(item1, this.transform.position, Quaternion.identity);
        }
        else if (count == 2)
        {
            CointManager.Instance.GetCoint(500);
            Instantiate(item2, this.transform.position, Quaternion.identity);
        }
        else if (count == 3)
        {
            CointManager.Instance.GetCoint(1000);
            Instantiate(item3, this.transform.position, Quaternion.identity);
        }
        else if (count == 4)
        {
            CointManager.Instance.GetCoint(200);
            Instantiate(item4, this.transform.position, Quaternion.identity);
        }
        else if (count == 5)
        {
            CointManager.Instance.GetCoint(600);
            Instantiate(item5, this.transform.position, Quaternion.identity);
        }
        else if (count == 6)
        {
            CointManager.Instance.GetCoint(1100);
            Instantiate(item6, this.transform.position, Quaternion.identity);
        }

    }
}
