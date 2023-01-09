using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float hp = 100f;
    [SerializeField] float speedEnemy = 1f;

    public PlayerDamage playerDamage;
    public TextMeshPro textDamageEnemy;
    public Animator animator;

    public GameObject coinObj;
    private void Start()
    {
        playerDamage = GameObject.Find("Player").GetComponent<PlayerDamage>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        textDamageEnemy.text = "- " + playerDamage.damagePlayer.ToString();

        slider.value = hp / 100;
        transform.Translate(-transform.forward * Time.deltaTime * speedEnemy);
        if (hp <= 0.01f)
        {
            Instantiate(coinObj, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            animator.SetBool("Appereance", true);
            Destroy(other.gameObject);
            hp -= playerDamage.damagePlayer;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("HP " + gameObject.name + " : " + hp);
        }
    }
}
