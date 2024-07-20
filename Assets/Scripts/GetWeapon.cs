using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{

    [SerializeField] private Transform weaponPosition;
    [SerializeField] private GameObject indicatorGet;
    [SerializeField] private GameObject indicatorDrop;
    [SerializeField] private float distanceToGetWeapon;
    [HideInInspector] public static GameObject weapon;

    
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (weapon!=null) 
        {
            weapon.transform.position = weaponPosition.position;

            if (Input.GetKeyDown(KeyCode.G))
            {
                DropWeapon();
            }
        }
        if (Physics.Raycast(ray, out hitInfo,distanceToGetWeapon) && hitInfo.collider.CompareTag("Weapon"))
        {
            if (indicatorGet!=null && hitInfo.collider.gameObject != weapon)
            {
                indicatorGet.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (weapon != null)
                {
                    DropWeapon();
                }
                if (indicatorDrop!=null)
                {
                    indicatorDrop.SetActive(true);
                }
                weapon = hitInfo.collider.gameObject;
                weapon.GetComponent<Rigidbody>().isKinematic = true;
                weapon.transform.SetParent(weaponPosition);
                weapon.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));

            }
        }
        else if (indicatorGet != null)
        {
            indicatorGet.SetActive(false);
        }
        
    }
    private void DropWeapon()
    {
        weapon.GetComponent<Rigidbody>().isKinematic = false;
        weapon.transform.SetParent(null);
        weapon = null;

        if (indicatorDrop != null)
        {
            indicatorDrop.SetActive(false);
        }
    }

}
