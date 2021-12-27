using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.baltamstudios.stellardomination
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField]
        float MAX_SIZE = 120;
        float MIN_SIZE = 30;
        Camera cam;
        public Ship[] subjects;

        // Start is called before the first frame update
        void Start()
        {
            cam = GetComponent<Camera>();
            subjects = FindObjectsOfType<Ship>();
        }

        public void PollPlayers()
        {
            Debug.Log("new player connected, polling players");
            subjects = FindObjectsOfType<Ship>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float minX = 1f;
            float minY = 1f;
            float maxX = 0f;
            float maxY = 0f;

            foreach (Ship s in subjects)
            {
                Vector3 viewPortPosition = cam.WorldToViewportPoint(s.transform.position);
                minX = Mathf.Min(minX, viewPortPosition.x);
                maxX = Mathf.Max(maxX, viewPortPosition.x);
                minY = Mathf.Min(minY, viewPortPosition.y);
                maxY = Mathf.Max(maxY, viewPortPosition.y);
            }

            var dX = maxX - minX;
            var dY = maxY - minY;
            if (dX > 0.75 || dY > 0.6)
            {
                cam.orthographicSize *= 2f;
            }
            else if (dX < 0.3 && dY < 0.4)
            {
                cam.orthographicSize *= 0.5f;
            }

            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, MIN_SIZE, MAX_SIZE);

        }
    }
}