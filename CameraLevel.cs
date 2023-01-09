using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel : MonoBehaviour
{
    public PlayerLook playerLook;
    [SerializeField] Vector3[] positionsCamera;
    public bool activNewxPosition;


    public GameObject[] firstWave;
    public GameObject[] secondWave;
    public GameObject[] thirdWave;

    [SerializeField] GameObject WinLoad;
    //private void Start()
    //{
    //    WinLoad = GameObject.Find("Win");
    //    //firstWave[0] = GameObject.Find("Enemy1");
    //    //secondWave[0] = GameObject.Find("Enemy2");
    //    //thirdWave[0] = GameObject.Find("Enemy3");
    //}
    private void Update()
    {
        //if (activNewxPosition)
        //    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, positionsCamera[1], 2 * Time.deltaTime);
        //else if (!activNewxPosition)
        //    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, positionsCamera[0], 2 * Time.deltaTime);
        if (firstWave[0].transform.childCount == 0)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, positionsCamera[1], 2 * Time.deltaTime);
            secondWave[0].SetActive(true);
        }
        if (secondWave[0].transform.childCount == 0)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, positionsCamera[2], 2 * Time.deltaTime);
            thirdWave[0].SetActive(true);
        }
        if (thirdWave[0].transform.childCount == 0)
        {
            WinLoad.SetActive(true);
            //Time.timeScale = 0f;
        }
    }

}
