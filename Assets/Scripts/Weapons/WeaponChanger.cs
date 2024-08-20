using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class WeaponChanger : MonoBehaviour
{
    [SerializeField] List<Animator> weaponList = new List<Animator>();
    [SerializeField] List<Transform> weaponChildernTransform = new List<Transform>();
    [SerializeField] List<Vector3> weaponPosition = new List<Vector3>();
    [SerializeField] List<Vector3> weaponRotation = new List<Vector3>();
    List<List<Vector3>> weaponsPostitionsList = new List<List<Vector3>>();
    List<List<Vector3>> weaponsRotationsList = new List<List<Vector3>>();

    private void Awake()
    {
        weaponList = this.GetComponentsInChildren<Animator>().ToList();
        foreach (var weapon in weaponList)
        {            
            weaponPosition.Clear();
            weaponChildernTransform = weapon.GetComponentsInChildren<Transform>().ToList();
            foreach(var weaponChild in weaponChildernTransform)
            {
                weaponPosition.Add(weaponChild.transform.localPosition);
               // weaponRotation.Add(weaponChild.transform.localRotation);
            }
            weaponsPostitionsList.Add(weaponPosition);
           // weaponsRotationsList.Add(weaponRotation);
        }
        ChooseWeapon(0);
        Debug.Log(weaponsPostitionsList.Count + "weaponsPostionList count");
    }

    private void Update()
    {
        if(InputManager.IsChooseWeapon1) 
        {
            ChooseWeapon(0);
        }
        if(InputManager.IsChooseWeapon2)
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
            weaponChildernTransform.Clear();
            weaponList[weaponNumber].gameObject.SetActive(true);
            weaponChildernTransform = weaponList[weaponNumber].GetComponentsInChildren<Transform>().ToList();
            
           for(int i=0; i < weaponChildernTransform.Count; i++)
            {
                //weaponChildernTransform[i].gameObject.transform.localPosition = weaponsPostitionsList[weaponNumber][i];
                //Debug.Log(weaponChildernTransform[i].gameObject.transform.position + "weapon children trasform");
                //Debug.Log(weaponsPostitionsList[weaponNumber][i] + "weapon position lis");
            }      
        }
    }
}