using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public static bool shootCamera = false;
    GameObject ammo;

    private void Awake() {
        ammo = GameObject.Find("ammoCount");
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        if(ManageFire.IsPressed && (EatCloud.ammoCount > 0))
        { 
            shootCamera = true;
            //EatCloud.totalCount -= EatCloud.perCloud;
            //EatCloud.ammoCount = (EatCloud.totalCount/EatCloud.perCloud);
            EatCloud.ammoCount--;
            ManageFire.IsPressed = false;
            Debug.Log("Pressed");
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
        else{
            shootCamera = false;
        }

        ammo.GetComponent<Text>().text = EatCloud.ammoCount.ToString();
    }
}
