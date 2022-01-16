using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class ShipChoice : NetworkBehaviour
    {
        public SDPlayer.ShipClass playerChoice;

        public void ChooseFighter()
        {
            ChooseShip(SDPlayer.ShipClass.fighter);           
        }

        public void ChooseCruiser()
        {
            float chance = 0.1f;

            if (Random.Range(0, 1f) < chance) {
                ChooseShip(SDPlayer.ShipClass.cruiserAlt);
            }
            else
            {
                ChooseShip(SDPlayer.ShipClass.cruiser);
            }
        }

        public void ChooseCarrier()
        {
            ChooseShip(SDPlayer.ShipClass.carrier);
        }

        void ChooseShip(SDPlayer.ShipClass chosenShip)
        {
            playerChoice = chosenShip;
//            GetComponent<Menu>().SendReadyMsg();

            /*ShipChoiceMessage choiceMessage = new ShipChoiceMessage();
            choiceMessage.chosenShip = chosenShip;
            if (connectionToServer != null)
                connectionToServer.Send<ShipChoiceMessage>(choiceMessage);
            else
                Debug.Log("ConnectionToServer is null");*/
        }
                
    }
}