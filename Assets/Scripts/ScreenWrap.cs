using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace com.baltamstudios.stellardomination

{
     public class ScreenWrap : NetworkBehaviour
    {
        Rigidbody rb;
        Renderer[] renderers;
        float lastWarpTime;

        // Start is called before the first frame update
        void Start()
        {
            renderers = GetComponentsInChildren<Renderer>();
            Debug.Log("Found " + renderers.Length + " Renderers");
            if (renderers == null || renderers.Length < 1)
            {
                
                Debug.Log("ScreenWrap: Missing renderer in " + name + ". Did you make changes to the object?");
            }

            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var cam = Camera.main;

            var viewportPosition = cam.WorldToViewportPoint(transform.position);

            Vector3 current_position = rb.position;

            var warp = false;

            if (viewportPosition.x > 1 || viewportPosition.x < 0)
            {
                viewportPosition.x = 1 - viewportPosition.x;
                warp = true;
            }

            if (viewportPosition.y > 1 || viewportPosition.y < 0)
            {
                warp = true;
                viewportPosition.y = 1 - viewportPosition.y;
            }

            //if (warp && (Time.time - lastWarpTime > 0.5f))
            if (warp)
            {
                
                Debug.Log("Warping from: " + cam.WorldToViewportPoint(transform.position) + ", to: " + viewportPosition);

                Plane plane = new Plane(Vector3.up, 0);
                float distance;
                Ray ray = cam.ViewportPointToRay(viewportPosition);
                if (plane.Raycast(ray, out distance))
                {
                    Vector3 newPosition = ray.GetPoint(distance);
                    newPosition.y = 0;
                    rb.MovePosition(newPosition);
                    lastWarpTime = Time.time;
                }
                
            }
         
           
        }


        bool CheckRenderers()
        {
            foreach (var renderer in renderers)
            {
                // If at least one render is visible, return true
                if (renderer.isVisible)
                {
                    return true;
                }
            }

            // Otherwise, the object is invisible
            return false;
        }
    }
}