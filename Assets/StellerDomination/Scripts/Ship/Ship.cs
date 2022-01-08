using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using com.baltamstudios.stellardomination.server;

namespace com.baltamstudios.stellardomination
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Ship : NetworkBehaviour
    {
        public UIDisplay playerUI;
        public Transform RotationPoint;

        [SerializeField]
        Renderer hullRenderer;

        [SerializeField]
        [SyncVar(hook = nameof(SetColor))]
        Color hullColor;
        [SyncVar(hook = nameof(SetName))]
        string playerName;

        void Start()
        {
            if (RotationPoint == null) RotationPoint = transform; //ensure center is initialised.
            hullRenderer = GetComponentInChildren<MeshRenderer>();
            if (hullRenderer == null)
            {
                Debug.Log("Couldn't find renderer in ship");
            }
        }

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            string newName = "Player" + Random.Range(100, 999);
            Color color = Random.ColorHSV();
            CmdSetupPlayer(newName, color);
        }

        public void SetColor(Color oldVal, Color newVal) {
            GetComponentInChildren<Renderer>().materials[1].color = newVal;
        }
        
        public void SetName(string oldVal, string newVal)
        {
            gameObject.name = newVal;
        }

        [Command]
        public void CmdSetupPlayer(string _name, Color _col)
        {
            playerName = _name;
            hullColor = _col;
        }

    }
}