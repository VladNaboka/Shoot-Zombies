using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyFight : MonoBehaviour
{
    public Enemy enemy;
    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        enemy.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.enabled = true;
        }
    }
}
