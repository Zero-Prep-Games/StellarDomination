using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


namespace com.baltamstudios.stellardomination
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Ship))]
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
        float ShipRotation = 5f;
        Ship _ship;

        [SerializeField]
        Text speedDisplay;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            _ship = GetComponent<Ship>();
            speedDisplay = FindObjectOfType<UIDisplay>().shipSpeed;
        }


        void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                float v = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1f); //only use Thrust, no reverse.
                float h = Input.GetAxis("Horizontal");

                MoveShip(h, v);

                speedDisplay.text = string.Format("{0}", rb.velocity.magnitude);
            }

        }

        [Command]
        public void MoveShip(float h, float v)
        {
            //Add thrust
            rb.AddForce(transform.forward * v * ShipAcceleration * Time.deltaTime, ForceMode.Force);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, ShipMaxSpeed);

            //Rotation
            transform.RotateAround(_ship.CentrePoint.position, transform.up, h * ShipRotation * Time.deltaTime);
            //transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}