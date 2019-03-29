using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject weaponToSwitchTo;

    public void Switch(GameObject currentWeapon)
    {
        currentWeapon.SetActive(false);
        weaponToSwitchTo.SetActive(true);
    }


}
