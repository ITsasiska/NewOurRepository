using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public int ammo;
    public int totalAmmo;
    public int maxAmmo;
    public float attackSpeed;
    public float reloadSpeed;
    public int range;

    public GameObject bullet;
    public Transform attackSpawn;
    private bool isReload;

    private void Update()
    {
        Debug.DrawRay(attackSpawn.position, attackSpawn.transform.up * 10f);

        if (Input.GetMouseButton(0) && (isReload == false))
        {
            BeginShoot();
        }
        else if (!Input.GetMouseButton(0))
        {
            EndShoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && (ammo != maxAmmo) && (totalAmmo > 0))
        {
            Invoke("Reload", reloadSpeed);
            isReload = true;
        }
    }

    public void BeginShoot()
    {
        if ((ammo > 0) && !IsInvoking("Shoot"))
            InvokeRepeating("Shoot", 0f, attackSpeed);
    }

    void Shoot()
    {
        if (ammo <= 0)
        {
            EndShoot();
            return;
        }
        //int rnd = Random.Range(-range, range);
        //Instantiate(bullet, attackSpawn.position, gameObject.transform.rotation);

        RaycastHit2D hit = Physics2D.Raycast(attackSpawn.position, attackSpawn.up * 10f);

        if (hit)
        {
            Debug.Log(hit.transform.name);
        }

        ammo -= 1;
    }

    void EndShoot()
    {
        CancelInvoke("Shoot");
    }

    void Reload()
    {
        if (totalAmmo >= maxAmmo)
        {
            totalAmmo = totalAmmo - (maxAmmo - ammo);
            ammo = maxAmmo;
        }
        else
        {
            ammo = totalAmmo;
            totalAmmo = 0;
        }
        isReload = false;
    }
}
