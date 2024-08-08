using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [System.Serializable]
    public class Skill
    {
        public GameObject skillPrefab;
        public Image BG_CountDown;
        public TextMeshProUGUI cooldownText;
        public float cooldown;
        [HideInInspector]
        public float cooldownRemaining;
        [HideInInspector]
        public bool isOnCooldown;
    }

    public Skill[] skills;
    public Transform dir;

    private void Awake()
    {
        foreach (var skill in skills)
        {
            skill.cooldownRemaining = 0f;  
            skill.isOnCooldown = false;   
            skill.BG_CountDown.fillAmount = 0f;
            skill.cooldownText.text = "";
        }
    }

    private void Update()
    {
        foreach (var skill in skills)
        {
            if (skill.isOnCooldown)
            {
                skill.cooldownRemaining -= Time.deltaTime;
                if (skill.cooldownRemaining <= 0)
                {
                    skill.cooldownRemaining = 0;
                    skill.isOnCooldown = false;
                }
                UpdateUI(skill);
            }
        }
    }
    public void CastSpell(int index)
    {
        if (index >= 0 && index < skills.Length)
        {
            var skill = skills[index];
            if (!skill.isOnCooldown)
            {
                if (index == 1)
                {
                    Movement.Instance.isCastingSkill = true;
                    PlayerAnimation.Instance.Skill1Aim();
                }          
                 Instantiate(skill.skillPrefab, dir.transform.position, Quaternion.identity);
                skill.cooldownRemaining = skill.cooldown;
                skill.isOnCooldown = true;
                UpdateUI(skill);

                StartCoroutine(EndSkill());
            }
        }
    }
    private IEnumerator EndSkill()
    {
        
        yield return new WaitForSeconds(1.3f);
        Movement.Instance.isCastingSkill = false;
        PlayerAnimation.Instance.EndUsingSkill();
    }

    private void UpdateUI(Skill skill)
    {
        skill.BG_CountDown.fillAmount = skill.cooldownRemaining / skill.cooldown;
        skill.cooldownText.text = skill.cooldownRemaining > 0 ? skill.cooldownRemaining.ToString("F1") : "";
    }
}
