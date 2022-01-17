using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class Bullet : NetworkBehaviour
    {
        [SyncVar]
        public GameObject owner;
        [SyncVar]
        public float damage;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == owner) return;
            if (other.gameObject.tag.Equals("Ship"))
            {
                Debug.Log(owner.name + " hit " + other.name + "for " + damage + " damage");
            }
        }
    }

  
}