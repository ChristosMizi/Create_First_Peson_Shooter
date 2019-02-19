using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour {

    [SerializeField]
    private float _damageEnemy = 10f; // variable damageEnemy
    public float _range = 100f; // how far the bullets go 
    public float _shootingTimer;
    public float _shootingCD = 0.4f; // time between shootings, shoots every 4 sec, this goes for pistol

    public ParticleSystem _muzzleFlash; // variable muzzleflash

    [SerializeField]
    private AudioSource _weaponAudio; // variable refference to weapon Audio source

    [SerializeField]
    private GameObject _hitMarkerPrefab; // variable Hitmarker

    AudioSource shootSound;

    AudioSource reloadSound;
    Animator anim;

    //  public GameObject HandRig;
    // public ParticleSystem particles;
    RaycastHit hitInfo;
  
   

  
   

    public GameObject _hitMarkerPrefabZombie;
    // private GameObject _impactEffectCrate;
    //  [SerializeField]
    //   private GameObject _hitMarkerPrefabHouse;

    public float _impactForce = 30f; // Add force
    [SerializeField]
    private int currentAmmo; // variable current Ammo
    private int maxAmmo = 200; // variable Max Ammo
    private bool _isReloading = false; // Reloading valrable 

    private UIManager _uiManager;

    public GameObject pistolGO;
    public GameObject machineGunGO;




    // Use this for initialization
    void Start()
    {

        currentAmmo = maxAmmo;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();


        AudioSource[] audios = GetComponents<AudioSource>();
        shootSound = audios[0];
        reloadSound = audios[1];
    }

    // Update is called once per frame
    void Update()
    {
        //    Shoot();
        //}
        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {


            Shoot();
        }
        else
        {
            _muzzleFlash.Stop();
            // _muzzleFlash.SetActive(false);
            //  _weaponAudio.Stop();
            shootSound.Stop();

            // anim.SetBool("PFire", false);



        }
        // if R key pressed reload
        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            pistolGO.GetComponent<Animator>().SetTrigger("reload");
            reloadSound.Play();
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
          
                currentAmmo--;
                _uiManager.UpdateAmmo(currentAmmo);

                // Muzzleflash
                _muzzleFlash.Play();


                //Audio
                if (shootSound.isPlaying == false)
                {
                    shootSound.Play();
                }
                // Animation Playing

                pistolGO.GetComponent<Animator>().Play("PistolAdsFire");
            



            // RayCasting
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;




            //check if we hit something
            //check for collisions
            if (Physics.Raycast(rayOrigin, out hitInfo,_range))
            {
                Debug.Log("Hit something" + hitInfo.transform.name);

                if (hitInfo.transform.tag == "Zombie")
                {

                    Enemy target = hitInfo.transform.GetComponent<Enemy>();
                    if (target != null)
                    {

                        Enemy enemyControllerScript1 = hitInfo.transform.GetComponent<Enemy>();
                        enemyControllerScript1.DeductEnemyHealth(_damageEnemy);
                        if (hitInfo.rigidbody != null)
                        {
                            hitInfo.rigidbody.AddForce(-hitInfo.normal * _impactForce);
                        }
                        GameObject bloodGO = Instantiate(_hitMarkerPrefabZombie, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                        if (hitInfo.rigidbody != null)
                        {
                            hitInfo.rigidbody.AddForce(-hitInfo.normal * _impactForce);
                        }
                        Destroy(bloodGO, 4);

                    }

                }
                else
                {
                    //Instantiate the the hitMarker
                    GameObject shootingGO = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(shootingGO, 3);
                }
                if (hitInfo.rigidbody != null)
                {
                    hitInfo.rigidbody.AddForce(-hitInfo.normal * _impactForce);
                }



                //if (hitInfo.transform.tag == "Zombie")
                //{
                //    GameObject particle = Instantiate(_hitMarkerPrefabZombie, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                //    //  GameObject particle = Instantiate(particles.gameObject, screenPos, Quaternion.identity) as GameObject;
                //    
                //}
                //if (hitInfo.transform.tag == "House")
                //{
                //    GameObject particle = Instantiate(_hitMarkerPrefabHouse, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                //    //  GameObject particle = Instantiate(particles.gameObject, screenPos, Quaternion.identity) as GameObject;
                //    Destroy(particle, 4);
                //}


                //Check if we hit crate
                //Destroy Method
                Destructable crate = hitInfo.transform.GetComponent<Destructable>();
                if (crate != null)
                {
                    crate.DestroyCrate();
                }


            }

        


       
    }
    // Reload ammunition
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        currentAmmo = maxAmmo;
        _isReloading = false;
        _uiManager.UpdateAmmo(currentAmmo);
    }
}
