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
        public int damage;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == owner) return;
            if (other.gameObject.tag.Equals("Ship"))
            {
                //Debug.Log(owner.name + " hit " + other.name + "for " + damage + " damage");
                if (isServer)
                {
                    other.GetComponent<Ship>().ApplyDamage(damage);
                    Destroy(gameObject); //destroyed on clients since this is the server.
                }


            }
        }
    }

  
}