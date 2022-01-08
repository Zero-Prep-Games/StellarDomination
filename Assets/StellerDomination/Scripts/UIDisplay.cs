using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.baltamstudios.stellardomination
{
    public class UIDisplay : MonoBehaviour
    {
        // Start is called before the first frame update
        public Text shipSpeed;
        public Ship localPlayer;
        public Text PositionY;
        public Text PositionX;
        public Text PositionZ;
        public Text ViewportX;
        public Text ViewPortY;

        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (localPlayer != null)
            {
                if (shipSpeed != null)
                    shipSpeed.text = string.Format("{0}", localPlayer.GetComponent<PlayerMovement>().ShipSpeed);

                if (PositionY != null) 
                    PositionY.text = "" + localPlayer.transform.position.y;

                if (PositionX != null)
                {

                    PositionX.text = "" + localPlayer.transform.position.x;
                    PositionZ.text = "" + localPlayer.transform.position.z;


                    var cam = Camera.main;

                    var viewportPosition = cam.WorldToViewportPoint(localPlayer.transform.position);

                    ViewportX.text = "" + viewportPosition.x;
                    ViewPortY.text = "" + viewportPosition.y;
                }
            }
        }
    }
}