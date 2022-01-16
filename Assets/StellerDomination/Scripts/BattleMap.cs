using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination.server
{
    public class BattleMap : NetworkBehaviour
    {
        public Ship[] prefabs;
        public NetworkStartPosition[] spawnPoints;
        public override void OnStartServer()
        {
            base.OnStartServer();
            int i = 0;
            foreach (PlayerContainer p in FindObjectsOfType<PlayerContainer>())
            {
                Ship shipObject = Instantiate(prefabs[(int)p.shipClass],spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                Debug.Log("Player: " + p.name + ", Ship: " + shipObject.name);
                NetworkServer.Spawn(shipObject.gameObject, p.gameObject);
                p.playerShip = shipObject;
                i++;
            }
        }
    }
}