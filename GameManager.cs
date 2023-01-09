using SFInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerColliderDanger;
    public GameObject player;
    public GameObject coinScore;

    public GameObject shopObj;
    public SFInventoryCell sFInventoryCell;
    public InventoryWeaponOn inventoryWeaponOn;

    
    public void ShopMenu()
    {
        shopObj.SetActive(true);
    }
    public void ShopMenuReturnGame()
    {
        shopObj.SetActive(false);
    }
    public void StartGameAttack()
    {
        if (sFInventoryCell?.item.Icon == inventoryWeaponOn.iconsWeapon[0] || sFInventoryCell?.item.Icon == inventoryWeaponOn.iconsWeapon[1])
        {
            //playerColliderDanger.SetActive(true);
            //player.GetComponent<CameraLevel>().enabled = true;
            //DontDestroyOnLoad(player);
            DontDestroyOnLoad(coinScore);
            //DontDestroyOnLoad(coinScore.GetComponent<Image>().GetComponent<Text>());
            SceneManager.LoadScene(1);
        }
    }


}
