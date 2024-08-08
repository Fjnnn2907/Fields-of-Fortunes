using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI DameText;

    private void Update()
    {
        HealthText.text = PlayerManger.Instance.maxHealth.ToString();
        DameText.text = PlayerAttack.Instance.Damege.ToString() + $" ~ {PlayerAttack.Instance.Damege + 2}";
    }
}
