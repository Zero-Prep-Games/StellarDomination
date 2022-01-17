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

        [SerializeField]
        [SyncVar]
        public Color hullColor;
        [SyncVar(hook = nameof(OnSetPlayerName))]
        [SerializeField]
        string playerName;

        public void Start()
        {
            DontDestroyOnLoad(this);
        }
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            Debug.Log("PlayerContainer for local player starting.");
            DontDestroyOnLoad(gameObject);
            //giving the ShipMenu a reference to the local player.
            FindObjectOfType<ShipMenu>().playerContainer = this;

            string newName = "Player" + Random.Range(100, 999);
            Color color = Random.ColorHSV();
            CmdSetupPlayer(newName, color);
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

        [Command]
        public void CmdSetupPlayer(string _name, Color _col)
        {
            Debug.Log($"Setting name and color for player {netId}: {_name}");
            playerName = _name;
            hullColor = _col;
        }

        public void OnSetPlayerName(string _old, string _new)
        {
            name = _new;
        }
    }
}