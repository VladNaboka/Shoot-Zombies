using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] Slider sliderHP;
    public float damagePlayer = 25f;
    public float damageEnemy = 15f;
    float hp = 100f;

    [SerializeField] GameObject Losemenu;
    private void Update()
    {
        sliderHP.value = hp / 100;
        if (hp <= 0.01f)
        {
            //Losemenu.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp -= damageEnemy;
        }
    }
}
