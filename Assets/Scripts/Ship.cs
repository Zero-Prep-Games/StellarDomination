using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Ship : NetworkBehaviour
    {

        public Transform RotationPoint;

        new Renderer renderer;

        // Start is called before the first frame update
        void Start()
        {
            if (RotationPoint == null) RotationPoint = transform; //ensure center is initialised.
            renderer = GetComponent<Renderer>();
        }



        // Update is called once per frame
        void Update()
        {

        }


    }
}