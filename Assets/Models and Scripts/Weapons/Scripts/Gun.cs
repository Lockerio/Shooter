using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;
    public float impactForce = 1000f;

    public float fire_rate = 40f;
    private float next_time_to_fire = 0f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fps_cam;
    public ParticleSystem muzzle_flash;
    public GameObject impact_effect;

    public Text ammoValue;

    public AudioSource audioShot;

    int bitmask = ~((1 << 8) | (1 << 9));


    private void Start()
    {
        currentAmmo = maxAmmo;
        ammoValue.text = currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0f)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= next_time_to_fire)
        {
            next_time_to_fire = Time.time + 1f / fire_rate;
            Shoot();
        }
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        ammoValue.text = currentAmmo.ToString();

        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--;

        audioShot.PlayOneShot(audioShot.clip);
        muzzle_flash.Play();

        ammoValue.text = currentAmmo.ToString();

        RaycastHit hit;
        if (Physics.Raycast(fps_cam.transform.position, fps_cam.transform.forward, out hit, range, bitmask))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            EnemyRigs enemyRig = hit.transform.GetComponent<EnemyRigs>();
            

            if (target != null)
            {
                target.Take_Damage(damage);
            }
            if (enemyRig != null)
            {
                enemyRig.Take_Damage(damage);
            }


            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impact_GO = Instantiate(impact_effect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact_GO, 0.5f);
        }
    }
}