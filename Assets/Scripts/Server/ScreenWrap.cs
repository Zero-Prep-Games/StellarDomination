using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace com.baltamstudios.stellardomination.server
{
    public class ScreenWrap : NetworkBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        CameraUtils cameraUtils;

        Ship[] players;

        Vector3 NewPosition0;
        Vector3 NewPosition1;

        float nextWrap;
        float WrapCooldown = 1f;

        void Start()
        {
            nextWrap = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            bool SwapVertical = false;
            bool SwapHorizontal = false;
            if (cameraUtils.IsMaxZoomLevel && (Time.time > nextWrap))
            {
                if ((cameraUtils.minX < 0.1f || cameraUtils.maxX > 0.9f))
                {
                    SwapHorizontal = true;
                }
                if ((cameraUtils.minY < 0.1f || cameraUtils.maxY > 0.9f))
                {
                    SwapVertical = true;
                }
            }
            if (SwapHorizontal || SwapVertical)
            {
                players = FindObjectsOfType<Ship>();
                if (players.Length < 2)
                    return;

                NewPosition0 = players[0].transform.position;
                NewPosition1 = players[1].transform.position;
                
                if (SwapHorizontal)
                {
                    float temp = NewPosition0.x;
                    NewPosition0.x = NewPosition1.x;
                    NewPosition1.x = temp;
                }
                if (SwapVertical)
                {
                    float temp = NewPosition0.z;
                    NewPosition0.z = NewPosition1.z;
                    NewPosition1.z = temp;
                }
                

                players[0].GetComponent<PlayerMovement>().targetPosition = NewPosition0;
                players[1].GetComponent<PlayerMovement>().targetPosition = NewPosition1;
                
                nextWrap = Time.time + WrapCooldown;

                Debug.Log($"{players[0].name} from {players[0].transform.position} to {NewPosition0}");

            }
        }
    }
}