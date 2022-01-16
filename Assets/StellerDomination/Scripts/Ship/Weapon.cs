using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class Weapon : NetworkBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        public Transform gunMuzzle;
        
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

      


    }
}