using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Ship : NetworkBehaviour
    {
        public UIDisplay playerUI;
        public Transform RotationPoint;

        new Renderer renderer;

        public override void OnStartClient()
        {
            FindObjectOfType<UIDisplay>().localPlayer = this;
            var cam = FindObjectOfType<Camera>();
            cam.GetComponent<CameraZoom>().PollPlayers();
            cam.GetComponent<CameraUtils>().RefreshPlayers();
        }

        void Start()
        {
            if (RotationPoint == null) RotationPoint = transform; //ensure center is initialised.
            renderer = GetComponent<Renderer>();
        }



        // Update is called once per frame
        void FixedUpdate()
        {
            

        }


    }
}