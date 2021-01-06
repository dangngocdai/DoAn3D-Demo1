using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : SingletonMonoBehaviour<CarUserControl>
    {
        private CarController m_Car; // the car controller we want to use

        public TypeStartusCar typeStartus;

        float input;
        public override void Awake()
        {
            // get the car controller
            base.Awake();
            m_Car = GetComponent<CarController>();
        }

        // Button Chân Ga: Di lên or xuống. tùy theo biến type của cần gạt
        // Button Chân Phanh: handBrake
        float handbrake = 0;
        float h;

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {

            h = SimpleInput.GetAxis("Horizontal");

            if (typeStartus == TypeStartusCar.N || enterPhanh)
            {
                handbrake = 1;
                return;
            }
            else
            {
                handbrake = -1;
            }
            input = CrossPlatformInputManager.GetAxis("Vertical");


            if (CrossPlatformInputManager.GetAxis("Vertical") != 0)
            {
                if (typeStartus == TypeStartusCar.D)
                {
                    input = 1;
                }
                if (typeStartus == TypeStartusCar.R)
                    input = -1;
            }
            else
            {
                input = 0;
            }
        }
        private void FixedUpdate()
        {
            m_Car.Move(h, input, input, handbrake);
        }

        bool enterPhanh = false;
        public void EnterPhanh()
        {
            enterPhanh = true;
        }
        public void ExitPhanh()
        {
            enterPhanh = false;
        }

        public void Forward()
        {
            input = 1;
        }
        public void Backward()
        {
            input = -1;
        }
    }


}
public enum TypeStartusCar
{
    D,
    N,
    R
}
