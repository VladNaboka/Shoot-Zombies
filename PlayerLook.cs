using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] GameObject player;

    public GameObject bullet;
    public Camera mainCamera;
    public Transform spawnBullet;

    public GameObject weaponMain;

    public float shootForce;
    public float shootTime;
    float spread;

    bool isShoot;
    public bool isActivWeapon = false;

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Enemy>())
    //    {
    //        player.transform.LookAt(other.transform.position);
    //        target = other.gameObject;
    //        //StartCoroutine(bulletStrike());
    //        Vector3 fwdTr = spawnBullet.transform.TransformDirection(Vector3.forward) * 10;
    //        Debug.DrawRay(spawnBullet.position, fwdTr, Color.red);
    //        if (Input.GetMouseButtonDown(0))
    //            Shoot();
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Enemy>())
    //    {
    //        target = other.gameObject;
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Enemy>())
    //    {
    //        target = other.gameObject;
    //        player.transform.LookAt(target.transform.position);
    //        if (!isShoot)
    //            StartCoroutine(bulletStrike());
    //    }
    //}
    //private void Update()
    //{
    //    //if (target != null && !isShoot)
    //    //{

    //    //    player.transform.LookAt(target.transform.position);
    //    //    StartCoroutine(bulletStrike());
    //    //}
    //}
    private void Shoot()
    {
        Vector3 fwd = spawnBullet.transform.TransformDirection(Vector3.forward) * 100;
        Ray ray = new Ray(spawnBullet.position, fwd);
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }
    IEnumerator bulletStrike()
    {
        isShoot = true;
        yield return new WaitForSeconds(shootTime);
        Shoot();
        isShoot = false;
    }


    public GameObject closest;
    public GameObject[] enemy;

    public string nearest;

    //void Start()
    //{
    //    enemy = GameObject.FindGameObjectsWithTag("Enemy");
    //}

    GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (FindClosestEnemy())
        {
            nearest = FindClosestEnemy().name;
            player.transform.LookAt(FindClosestEnemy().transform.position);
            if (!isShoot/* && FindClosestEnemy()*/ && isActivWeapon)
            {
                StartCoroutine(bulletStrike());
            }
        }
        else
        {
            player.transform.rotation = Quaternion.identity;
        }
        Vector3 fwdTr = spawnBullet.transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(spawnBullet.position, fwdTr, Color.red);
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    //    }
    //}
}

