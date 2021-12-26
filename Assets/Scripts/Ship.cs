using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class Ship : NetworkBehaviour
    {

        public Transform CentrePoint;

        new Renderer renderer;

        // Start is called before the first frame update
        void Start()
        {
            if (CentrePoint == null) CentrePoint = transform; //ensure center is initialised.
            renderer = GetComponent<Renderer>();
        }



        // Update is called once per frame
        void Update()
        {

        }


    }
}