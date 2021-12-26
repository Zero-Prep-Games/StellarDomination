using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


namespace com.baltamstudios.stellardomination
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : NetworkBehaviour
    {

        Rigidbody rb;
        [SerializeField]
        float ShipAcceleration = 1f;
        [SerializeField]
        float ShipMass = 1f;
        [SerializeField]
        float ShipMaxSpeed = 10f;
        [SerializeField]
        float ShipRotation = 45f; //degrees/sec
        Ship shipObject;

        public float ShipSpeed;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            shipObject = GetComponent<Ship>();
        }


        void FixedUpdate()
        {
            if (this.isLocalPlayer)
            {
                float v = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1f); //only use Thrust, no reverse.
                float h = Input.GetAxis("Horizontal");

                MoveShip(h, v);

                ShipSpeed = rb.velocity.magnitude;
            }

        }

        //[Command]
        public void MoveShip(float h, float v)
        {
            //Add thrust
            rb.AddForce(transform.forward * v * ShipAcceleration * Time.deltaTime, ForceMode.Force);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, ShipMaxSpeed);

            //Rotation

            Vector3 rotationAngle = new Vector3(0, ShipRotation * h, 0);
            Quaternion deltaRotation = Quaternion.Euler(rotationAngle * Time.fixedDeltaTime);
            rb.MoveRotation(deltaRotation * rb.rotation);
            
        }
    }
}