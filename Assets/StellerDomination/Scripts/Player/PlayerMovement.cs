using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class PlayerMovement : NetworkBehaviour
    {
        PlayerContainer playercontainer;
        // Start is called before the first frame update
        void Start()
        {
            playercontainer = GetComponent<PlayerContainer>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (this.isLocalPlayer && playercontainer.playerShip != null)
            {
                float v = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1f); //only use Thrust, no reverse.
                float h = Input.GetAxis("Horizontal");

                playercontainer.playerShip.MoveShip(h, v);

                //ShipSpeed = rb.velocity.magnitude;
            }
        }
    }
}