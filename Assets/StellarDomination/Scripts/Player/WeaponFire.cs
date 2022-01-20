using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
        public class WeaponFire : NetworkBehaviour
    {
        bool firePressed = false;
            // Weapon weapon;
        PlayerContainer player;
        private void Start()
        {
            player = GetComponent<PlayerContainer>();
        }

        void Update()
        {
            if (isLocalPlayer && player.playerShip != null && !player.playerShip.shipDisabled)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log(name + ": Fire");
                    firePressed = true;
                }

            }
        }

        public void FixedUpdate()
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
            if (player.playerShip != null && player.playerShip.weapon.energyCost <= player.playerShip.energy)
            {
                Weapon weapon = player.playerShip.weapon;
                Bullet bullet = Instantiate(weapon.bulletPrefab, weapon.gunMuzzle.transform.position, Quaternion.identity);
                bullet.owner = player.playerShip.gameObject;
                bullet.damage = weapon.damage;
                Destroy(bullet.gameObject, weapon.duration);
                bullet.GetComponent<Rigidbody>().AddForce(weapon.gunMuzzle.transform.forward.normalized * weapon.bulletSpeed, ForceMode.VelocityChange);
                NetworkServer.Spawn(bullet.gameObject);
                player.playerShip.energy -= weapon.energyCost;
                RpcPlayNoise();
            }
            else if (player.playerShip != null)
            {
                Debug.Log($"{name} Out of energy");
            }
            
        }

        [ClientRpc]
        public void RpcPlayNoise()
        {
            Debug.Log($"{name}: pew pew! with {player.playerShip}");
            if (player != null && player.playerShip != null)
                player.playerShip.weapon.PlayNoise();
        }
            
    }
}