using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerPlayer : MonoBehaviour
{
    [SerializeField] Transform player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.transform.LookAt(player.transform.position);
            other.gameObject.transform.rotation = transform.rotation;
        }
    }
}
