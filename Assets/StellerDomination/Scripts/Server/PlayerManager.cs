using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

namespace com.baltamstudios.stellardomination.server
{
    public class PlayerManager : NetworkBehaviour
    {
        public void Update()
        {
            if(isServer)
            {
                bool AllPlayersReady = true;
                PlayerContainer[] players = FindObjectsOfType<PlayerContainer>();
                if (players.Length > 1)
                {
                    foreach (PlayerContainer p in players)
                    {
                        AllPlayersReady &= p.isReady;
                    }

                    if (AllPlayersReady)
                    {
                        NetworkManager.singleton.ServerChangeScene("BattleMap");
                    }
                }
            }

        }
    }
}