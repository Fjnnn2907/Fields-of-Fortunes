using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    [SerializeField] GameObject Skill;
    [SerializeField] Transform PosSkill;

    public void Spell()
    {
        Instantiate(Skill, PosSkill.position, Quaternion.identity);
    }

}
