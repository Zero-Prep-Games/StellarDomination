using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class Menu : MonoBehaviour
    {
        public NetworkManager networkManager;
        public InputField address;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartHost()
        {
            NetworkManager.singleton.StartHost();
        }

        public void StartClient()
        {
            if (address.text == null || address.text == "")
            {
                address.text = "http://127.0.0.1";
            }
            else
            {
                address.text = "http://" + address.text;
            }
            Debug.Log("Starting client at address " + address.text);
            NetworkManager.singleton.StartClient(new System.Uri(address.text));
        }
    }
}