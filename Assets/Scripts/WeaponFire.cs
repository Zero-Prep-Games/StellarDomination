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
        public float duration = 5f; //lifetime in seconds
        public float energyCost = 1f; //energy cost

        void Start()
        {
            owner = gameObject;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (this.isLocalPlayer && Input.GetButtonDown("Fire1"))
            {
                CmdFire();
            }
        }

        [Command]
        public void CmdFire()
        {

        }
    }
}