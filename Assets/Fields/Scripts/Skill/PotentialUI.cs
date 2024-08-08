using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotentialUI : MonoBehaviour
{
    public TextMeshProUGUI potentialText;
    public TextMeshProUGUI PointText;
    public TextMeshProUGUI PointText1;

    private void Update()
    {
        potentialText.text = "Potentia: " + PotentialManager.Instance.potential.ToString();
        PointText.text =  PotentialManager.Instance.Point.ToString();
        PointText1.text = PotentialManager.Instance.Point1.ToString();
    }
}
