using System.Collections;
using UnityEngine;

public class Pewpew : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Sup;
    public float damage = 11f;
    public float range = 100f;
    public GameObject impactEffect;
    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public string whichGun;
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(whichGun == "Automatic")
            {
                StartCoroutine(Automatic());
            }else if (whichGun == "Burst" && canShoot == true)
            {
                StartCoroutine(BurstFire());
            } else
            {
                Shoot();
                canShoot = true;
            }
        }
    }

    void Shoot ()
    {
        audioSource.PlayOneShot(Sup);
        MuzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            else if (target == null)
            {
               ButtonTarget buttonTargot = hit.transform.GetComponent<ButtonTarget>();
                if (buttonTargot != null)
                {
                    buttonTargot.TakeDamage(damage);
                }

                WeaponSwitch weaponSwitch = hit.transform.GetComponent<WeaponSwitch>();
                if (weaponSwitch != null)
                {
                    weaponSwitch.Switch(gameObject);

                }
            }
        }

       GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);
    }

    IEnumerator BurstFire()
    {
        canShoot = false;
        for (int i = 0; i < 3; i++)
        {
            Shoot();
            //Time between burst shots
            yield return new WaitForSeconds(0.1f);
        }
        //Time between being able to burst
        yield return new WaitForSeconds(0.1f);
        canShoot = true;
    }

    IEnumerator Automatic()
    {
        while (Input.GetButton("Fire1"))
        {
            Shoot();
            yield return new WaitForSeconds(0.08f);
        }
       
    }

    private void OnEnable()
    {
        canShoot = true;
    }
}
