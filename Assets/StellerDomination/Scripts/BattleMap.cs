using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination.server
{
    public class BattleMap : NetworkBehaviour
    {

        public BattleUI player1UI;
        public BattleUI player2UI;


        public Ship[] prefabs;
        public NetworkStartPosition[] spawnPoints;
        public override void OnStartServer()
        {
            base.OnStartServer();

            PlayerContainer[] players = FindObjectsOfType<PlayerContainer>();
            int i = 0;
            foreach (PlayerContainer p in players)
            {
                Ship shipObject = Instantiate(prefabs[(int)p.shipClass],spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                Debug.Log("Player: " + p.name + ", Ship: " + shipObject.name);
                NetworkServer.Spawn(shipObject.gameObject, p.gameObject);
                p.playerShip = shipObject;
                i++;
            }

            //Give each player acccess to their own UI.
            players[0].battleUI = player1UI;
            players[1].battleUI = player2UI;
            
        }
    }
}