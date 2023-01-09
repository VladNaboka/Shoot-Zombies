using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAddScore : MonoBehaviour
{
    public Text textScore;
    public float score;
    [SerializeField] float addCoinScore = 5f;
    public GameObject parentCanvas;
    public static CoinAddScore Instance;
    private void Start()
    {
        textScore = GameObject.Find("CoinTextMain").GetComponent<Text>();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(parentCanvas);
            Instance = this;
        }
        else
        {
            Destroy(parentCanvas);
        }

    }
    private void Update()
    {
        textScore.text = score.ToString();
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Coin"))
    //    {
    //        Destroy(collision.gameObject);
    //        score += addCoinScore;
    //    }
    //}
}
