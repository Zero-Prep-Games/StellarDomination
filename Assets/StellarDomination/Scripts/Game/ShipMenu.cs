using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using com.baltamstudios.stellardomination.server;

namespace com.baltamstudios.stellardomination
{
    public class ShipMenu : NetworkBehaviour
    {
        const float ALTPROBABILITY = 0.1f;
        public PlayerContainer playerContainer;

        public void Start()
        {
            
            Debug.Log($"Trying to connect to local player - Network Identity - {NetworkClient.localPlayer.gameObject.name}");
            playerContainer = NetworkClient.localPlayer.GetComponent<PlayerContainer>();
            if (playerContainer == null)
            {
                Debug.Log("Couldn't find local player!");
            }
        }
        public void PickFighter()
        {
            playerContainer.ChooseShip(SDPlayer.ShipClass.fighter);
        }

        public void PickCruiser()
        {
            if (Random.Range(0, 1f) < ALTPROBABILITY)
            {
                playerContainer.ChooseShip(SDPlayer.ShipClass.cruiserAlt);
            }
            else playerContainer.ChooseShip(SDPlayer.ShipClass.cruiser);
        }

        public void PickCarrier()
        {
            playerContainer.ChooseShip(SDPlayer.ShipClass.carrier);
        }

    }
}