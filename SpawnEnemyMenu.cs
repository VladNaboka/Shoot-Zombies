using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyMenu : MonoBehaviour
{
	public GameObject RightSide;
	public GameObject[] items;
	public float startDelay, repeatRate;
	void Start()
	{
		InvokeRepeating("Spawn", startDelay, repeatRate);
	}

	void Spawn()
	{
		Vector3 pos = new Vector3(Random.Range(gameObject.transform.position.x, RightSide.transform.position.x), gameObject.transform.position.y, gameObject.transform.position.z);
		Instantiate(items[Random.Range(0, items.Length)], pos, gameObject.transform.rotation);
		items[0].SetActive(true);
	}
}
