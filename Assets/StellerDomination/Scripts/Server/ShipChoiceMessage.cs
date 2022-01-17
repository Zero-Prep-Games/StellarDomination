using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public struct ShipChoiceMessage : NetworkMessage
    {
        public SDPlayer.ShipClass chosenShip;

        public ShipChoiceMessage(SDPlayer.ShipClass ship)
        {
            chosenShip = ship;
        }
    }
   
}