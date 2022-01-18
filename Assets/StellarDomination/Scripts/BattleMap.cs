using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace com.baltamstudios.stellardomination.server
{
    public class BattleMap : NetworkBehaviour
    {

        public BattleUI player1UI;
        public BattleUI player2UI;

        public GameObject ExplosionPrefab;

        public Ship[] prefabs;
        public NetworkStartPosition[] spawnPoints;

        public Text WinLoseMessage;

        public Ship[] shipsInPlay;

        public override void OnStartServer()
        {
            base.OnStartServer();

            shipsInPlay = new Ship[2];

            PlayerContainer[] players = FindObjectsOfType<PlayerContainer>();
            int i = 0;
            foreach (PlayerContainer p in players)
            {
                Ship shipObject = Instantiate(prefabs[(int)p.shipClass],spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                shipObject.owner = p;
                Debug.Log("Player: " + p.name + ", Ship: " + shipObject.name);
                NetworkServer.Spawn(shipObject.gameObject, p.gameObject);
                p.playerShip = shipObject;
                shipsInPlay[i] = shipObject;
                i++;
            }

            //Give each player acccess to their own UI.
            players[0].battleUI = player1UI;
            players[1].battleUI = player2UI;
            
        }

        public void Update()
        {
            if (isServer)
            {
                foreach(Ship s in shipsInPlay)
                {
                    if (s.crew <= 0 && !s.HasExploded)
                    {
                        Camera cam = Camera.main;
                        //this is to create the explosion slightly closer to the camera than the ship.
                        Vector3 offset = cam.GetComponent<CameraUtils>().cameraPositionOffset.normalized * 0.1f;
                        s.HasExploded = true; //prevent this from running on subsequent frames
                        GameObject explosion = Instantiate(ExplosionPrefab, s.transform.position + offset, Quaternion.identity);
                        NetworkServer.Spawn(explosion);
                        Destroy(explosion, 1f);
                        s.Disable();
                        s.owner.playerShip = null;
                        
                        Destroy(s.gameObject, 1f);
                    }
                }
                
            }
            
        }

        public void CountLoss(PlayerContainer losingPlayer)
        {
            Debug.Log($"{losingPlayer.name} has lost");
            if (losingPlayer.isLocalPlayer)
            {
                WinLoseMessage.text = "You Lose!";
            }
            else
                WinLoseMessage.text = "You Win!";

            WinLoseMessage.enabled = true;
        }
    }
}