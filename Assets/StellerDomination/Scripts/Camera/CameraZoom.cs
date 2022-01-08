using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.baltamstudios.stellardomination
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField]
        float[] zoomSteps;
        int currZoomStep = 1;
        CameraUtils cameraUtils;

        public bool IsMaxZoomLevel
        {
            get { return currZoomStep == zoomSteps.Length - 1; }
        }

        [SerializeField]
        float zoomOutThreshold = 0.05f;
        [SerializeField]
        float zoomInThreshold = 0.45f;

        // Start is called before the first frame update
        void Start()
        {
            cameraUtils = GetComponent<CameraUtils>();
            cameraUtils.cam.orthographicSize = zoomSteps[currZoomStep];
        }
        // Update is called once per frame
        void Update()
        {
            if (cameraUtils.NumTargets > 1) //only if there are more than one player
            {
                
                //if the ships are close to the edge of the screen and we have additional zoom steps:
                if ((cameraUtils.minX < zoomOutThreshold || cameraUtils.minY < zoomOutThreshold
                    || cameraUtils.maxX > 1f-zoomOutThreshold || cameraUtils.maxY > 1f-zoomOutThreshold) //redundant but handles some edge cases due to orthogonal camera
                    &&
                    currZoomStep < zoomSteps.Length - 1)
                {
                    Debug.Log($"Prezoom status: {cameraUtils.minX}, {cameraUtils.maxX}, {cameraUtils.minY}, {cameraUtils.maxY}");
                    currZoomStep++;
                }
                else if ((cameraUtils.minX > zoomInThreshold && cameraUtils.minY > zoomInThreshold)
                    &&
                    currZoomStep > 0)
                {
                    Debug.Log($"Prezoom status: {cameraUtils.minX}, {cameraUtils.maxX}, {cameraUtils.minY}, {cameraUtils.maxY}");
                    currZoomStep--;
                }
                

                cameraUtils.cam.orthographicSize = zoomSteps[currZoomStep];
            }
            
        }
    }
}