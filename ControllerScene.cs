using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScene : MonoBehaviour
{
    public PlayerLook playerLook;
    public GameObject coinScore;
    public GameObject pointCoin;
    private void Start()
    {
        playerLook = GameObject.Find("PlayerCollider").GetComponent<PlayerLook>();
        coinScore = GameObject.Find("CanvasCoin");
        pointCoin = GameObject.Find("pointCoin");
    }
    public void UpSpeedButtonDown()
    {
        playerLook.shootTime = 0.5f;
    }
    public void UpSpeedButtonUp()
    {
        playerLook.shootTime = 1f;
    }

    public void ReturnMenu()
    {
        //DontDestroyOnLoad(coinScore);
        SceneManager.LoadScene(0);
    }
}
