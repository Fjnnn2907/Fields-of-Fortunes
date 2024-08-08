using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CointUI : MonoBehaviour
{
    public TextMeshProUGUI CountTxtUI;

    private void Update()
    {
        CountTxtUI.text = CointManager.Instance.Coint.ToString();
    }
}
