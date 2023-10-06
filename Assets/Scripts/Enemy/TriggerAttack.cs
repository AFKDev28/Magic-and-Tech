using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    [SerializeField] private Attacks attack;

    public void TriggeringAttack()
    {
        attack.AniTriggerAttack();
    }
}
