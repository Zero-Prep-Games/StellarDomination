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

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (localPlayer != null)
            {
                shipSpeed.text = string.Format("{0}", localPlayer.GetComponent<PlayerMovement>().ShipSpeed);
            }
        }
    }
}