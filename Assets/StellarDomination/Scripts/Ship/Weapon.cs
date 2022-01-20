using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    [RequireComponent(typeof(AudioSource))]
    public class Weapon : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        public Transform gunMuzzle;
        [SerializeField]
        AudioSource gunSound;
        
        public Bullet bulletPrefab;
        GameObject owner;

        public int damage = 10;
        public float duration = 0.5f; //lifetime in seconds
        public int energyCost = 1; //energy cost
        public float bulletSpeed = 100f;

        bool firePressed = false;

        void Start()
        {
            owner = gameObject;
            gunSound = GetComponent<AudioSource>();
        }

        public void PlayNoise()
        {
            gunSound.Play();
        }

      


    }
}