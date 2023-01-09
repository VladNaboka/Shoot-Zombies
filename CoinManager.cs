using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject pointCoin;
    public CoinAddScore coinAddScore;
    private void Start()
    {
        coinAddScore = FindObjectOfType<CoinAddScore>();
        pointCoin = GameObject.Find("pointCoin");
    }
    void Update()
    {
        StartCoroutine(coinTranslate());
    }
    IEnumerator coinTranslate()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.position = Vector3.Lerp(transform.position, pointCoin.transform.position, 3 * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pointCoin")
        {
            Destroy(gameObject);
            coinAddScore.score += 5f;
        }
    }
}
