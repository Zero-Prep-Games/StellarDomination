using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class WeaponFire : NetworkBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        Transform gunMuzzle;
        
        public Bullet bulletPrefab;
        GameObject owner;

        public float damage = 10f;
        public float duration = 0.5f; //lifetime in seconds
        public float energyCost = 1f; //energy cost
        public float bulletSpeed = 100f;

        bool firePressed = false;

        void Start()
        {
            owner = gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer) 
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log(name + ": Fire");
                    firePressed = true;
                }
                
            }
        }


        private void FixedUpdate()
        {
            if (firePressed)
            {
                CmdFire();
                firePressed = false;
            }
        }
        [Command]
        public void CmdFire()
        {
            Debug.Log("Server executing Fire for " + name);
            Bullet bullet = Instantiate(bulletPrefab, gunMuzzle.transform.position, Quaternion.identity);
            bullet.owner = gameObject;
            Destroy(bullet.gameObject, duration);
            bullet.GetComponent<Rigidbody>().AddForce(gunMuzzle.transform.forward.normalized * bulletSpeed, ForceMode.VelocityChange);
            NetworkServer.Spawn(bullet.gameObject);

        }
    }
}