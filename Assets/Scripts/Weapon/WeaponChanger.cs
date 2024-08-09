using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class WeaponChanger : MonoBehaviour
{
    [SerializeField] List<Animator> weaponList = new List<Animator>();

    private void Awake()
    {
        weaponList = this.GetComponentsInChildren<Animator>().ToList();
        ChooseWeapon(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            ChooseWeapon(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseWeapon(1);
        }
    }

    private void ChooseWeapon(int weaponNumber)
    {
        foreach (var weapon in weaponList)
        {
            weapon.gameObject.SetActive(false);
        }
        if(weaponList.Count<=weaponNumber || weaponNumber < 0)
        {
            return;
        }
        else
        {
            weaponList[weaponNumber].gameObject.SetActive(true);
        }
    }
}