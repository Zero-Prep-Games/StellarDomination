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

        [SerializeField]
        Renderer hullRenderer;

        ShipMovement shipMovement;
        void Start()
        {
            if (RotationPoint == null) RotationPoint = transform; //ensure center is initialised.
            hullRenderer = GetComponentInChildren<MeshRenderer>();
            if (hullRenderer == null)
            {
                Debug.Log("Couldn't find renderer in ship");
            }
            shipMovement = GetComponent<ShipMovement>();
        }


        public void SetColor(Color col)
        {
            GetComponentInChildren<Renderer>().materials[1].color = col;
        }
        
        public void MoveShip(float h, float v)
        {
            shipMovement.MoveShip(h, v);
        }

    }
}