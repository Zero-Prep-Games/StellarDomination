using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.baltamstudios.stellardomination
{
    // Keeps the camera zoomed in or out as the players get closer.
    public class CameraCentre : MonoBehaviour
    {
        CameraUtils cameraUtils;
        
        // Start is called before the first frame update
        void Start()
        {
            cameraUtils = GetComponent<CameraUtils>();
            
        }


        // Update is called once per frame
        void FixedUpdate()
        {




            transform.position = cameraUtils.centreOfMass + cameraUtils.cameraPositionOffset;
        }
    }
}