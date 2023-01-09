using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageManager : MonoBehaviour
{
    public TextMeshPro[] textDamageEnemy;
    public PlayerDamage playerDamage;

    private void Update()
    {
        textDamageEnemy[0].text = playerDamage.damagePlayer.ToString();
    }
}
