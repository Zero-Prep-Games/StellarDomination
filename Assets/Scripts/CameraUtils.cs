using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.baltamstudios.stellardomination
{
    public class CameraUtils : MonoBehaviour
    {
        Ship[] playerShips;
        public int NumTargets
        {
            get { return playerShips.Length; }
        }

        public Vector3 centreOfMass;
        public Vector3 cameraPositionOffset;

        //viewport positions
        public float minX;
        public float maxX;
        public float minY;
        public float maxY;

        public Camera cam;
        // Start is called before the first frame update
        void Start()
        {
            cam = GetComponent<Camera>();
            playerShips = new Ship[0];
            cameraPositionOffset = transform.position;   
        }

        public void RefreshPlayers()
        {
            playerShips = FindObjectsOfType<Ship>();
            Debug.Log("Player connected, updating number of players in camera. Total ships: "+playerShips.Length);

        }
        // Update is called once per frame
        void FixedUpdate()
        {
            playerShips = FindObjectsOfType<Ship>();

            if (playerShips.Length > 0)
            {
                maxX = 0;
                maxY = 0;
                minX = 1f;
                minY = 1f;
                centreOfMass = Vector3.zero;

                foreach (Ship s in playerShips)
                {
                    Vector3 viewPortPosition = cam.WorldToViewportPoint(s.transform.position);
                    minX = Mathf.Min(minX, viewPortPosition.x);
                    maxX = Mathf.Max(maxX, viewPortPosition.x);
                    minY = Mathf.Min(minY, viewPortPosition.y);
                    maxY = Mathf.Max(maxY, viewPortPosition.y);
                    centreOfMass += s.transform.position;
                }

                centreOfMass /= playerShips.Length;
            }
            else
            {
                maxX = 0.5f;
                maxY = 0.5f;
                minX = 0.5f;
                minY = 0.5f;
                centreOfMass = Vector3.zero;
            }

        }
    }
}