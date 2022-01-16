using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using com.baltamstudios.stellardomination.server;

namespace com.baltamstudios.stellardomination
{
    // This class is used as the "placeholder" for a player without a model, to be active during the menu and ship selection screens.
    // in the arena, the player class should be replaced with the ship class.

    public class PlayerContainer : NetworkBehaviour
    {
        [SyncVar]
        public SDPlayer.ShipClass shipClass;
        [SyncVar]
        public bool isReady = false;
        [SyncVar]
        public Ship playerShip;

        public void Start()
        {
            DontDestroyOnLoad(this);
        }
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            DontDestroyOnLoad(gameObject);
            FindObjectOfType<ShipMenu>().playerContainer = this;
        }

        public void ChooseShip(SDPlayer.ShipClass s)
        {
            if (isLocalPlayer)
            {
                Debug.Log(name + ": Player choosing ship: " + s.ToString() + "on connection: "+connectionToServer.connectionId);
                CmdPlayerShipChoice(s);
            }
        }

        [Command]
        public void CmdPlayerShipChoice(SDPlayer.ShipClass s)
        {
            this.shipClass=s;
            isReady = true;
        }
    }
}