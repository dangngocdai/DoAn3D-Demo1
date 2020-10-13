using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using SimpleInputNamespace;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

    float input;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = SimpleInput.GetAxis("Horizontal");
            input = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, input, input, handbrake);
#else
            m_Car.Move(h, input, input, 0f);
#endif
        }

        public void Forward(){
            input = 1;
        }
        public void Backward(){
            input = -1;
        }
    }
}
