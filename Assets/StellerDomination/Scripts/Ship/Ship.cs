using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using com.baltamstudios.stellardomination.server;

namespace com.baltamstudios.stellardomination
{
    [RequireComponent(typeof(ShipMovement))]
    public class Ship : NetworkBehaviour
    {
        public UIDisplay playerUI;
        public Transform RotationPoint;
        public int crew;
        [SerializeField]
        int MaxCrew = 50;
        public float energy;
        [SerializeField]
        float MaxEnergy = 25f;
        [SerializeField, Tooltip("Energy units gained per second.")]
        float EnergyRechargeRate = 5f;

        public Weapon weapon;

        [SerializeField]
        Renderer hullRenderer;

        ShipMovement shipMovement;
        void Start()
        {
            crew = MaxCrew;
            energy = MaxEnergy;

            if (RotationPoint == null) RotationPoint = transform; //ensure center is initialised.
            hullRenderer = GetComponentInChildren<MeshRenderer>();
            if (hullRenderer == null)
            {
                Debug.Log("Couldn't find renderer in ship");
            }
            shipMovement = GetComponent<ShipMovement>();
            weapon = GetComponentInChildren<Weapon>();
        }

        private void Update()
        {
            //could do this for server only and apply a syncvar, but it's fine to do it on the client, since the server determines ability to shoot anyway.

            //Recharge energy
            if (energy < MaxEnergy)
            {
                energy += EnergyRechargeRate * Time.deltaTime;
            }
        }

        public void SetColor(Color col)
        {
            GetComponentInChildren<Renderer>().materials[1].color = col;
        }
        
        public void MoveShip(float h, float v)
        {
            if (shipMovement != null)
            {
                shipMovement.MoveShip(h, v);
            }
            else
            {
                Debug.Log($"{name}: Why is the ship moving?");
            }
            
        }

        public void ApplyDamage(int dmg)
        {
            //just double-checking
            if (isServer)
            {
                crew -= dmg;
                if (crew <= 0)
                {
                    Debug.Log($"{name}'s ship destroyed!");
                }
                //syncvar should take care of the rest
            }
        }



    }
}