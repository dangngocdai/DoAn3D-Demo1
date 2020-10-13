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

// Button Chân Ga: Di lên or xuống. tùy theo biến type của cần gạt
// Button Chân Phanh: handBrake
float handbrake = 0;
        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = SimpleInput.GetAxis("Horizontal");
            input = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            handbrake = CrossPlatformInputManager.GetAxis("Jump");    
#endif
 m_Car.Move(h, input, input, handbrake);
        }

        public void Forward(){
            input = 1;
        }
        public void Backward(){
            input = -1;
        }
    }

    public enum TypeStartusCar{
        P,
        N,
        F,B
    }
}
