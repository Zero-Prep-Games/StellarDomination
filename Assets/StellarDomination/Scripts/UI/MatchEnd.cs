using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class MatchEnd : NetworkBehaviour
    {
        public GameObject AgainButton;
        public GameObject ShipChoiceButton;
        public GameObject ResultsUI;
        public Text ResultText;

        public void Again()
        {
            NetworkManager.singleton.ServerChangeScene("BattleMap");
        }

        public void ShipCoiceMenu()
        {
            foreach (PlayerContainer p in FindObjectsOfType<PlayerContainer>())
            {
                p.isReady = false;
                p.playerShip = null;
                NetworkManager.singleton.ServerChangeScene("ShipSelect");
            }
        }
        
        [ClientRpc]
        public void RpcShowResults(PlayerContainer losingPlayer)
        {
            if (losingPlayer.netId == NetworkClient.localPlayer.netId)
            {
                ResultText.text = "You Lose!";
            }
            else ResultText.text = "You Win!";

            ResultsUI.SetActive(true);

            if (isServer) //this is the host
            {
                AgainButton.SetActive(true);
                ShipChoiceButton.SetActive(true);
            }
            else
            {
                AgainButton.SetActive(false);
                ShipChoiceButton.SetActive(false);
            }
        }
    }
}