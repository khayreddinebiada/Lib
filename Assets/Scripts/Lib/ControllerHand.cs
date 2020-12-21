using System;
using UnityEngine;

namespace game.ui
{
    public class ControllerHand : MonoBehaviour
    {
        #region variables
        private ControllerInputs _controllerInputs;

        [SerializeField]
        private Transform backgroundHand;
        [SerializeField]
        private Transform movingHand;
        #endregion

        #region default functions
        void Start()
        {
            _controllerInputs = ControllerInputs.instance;
        }

        // Update is called once per frame
        void Update()
        {
            MovingHand();
            ActivateHand();
        }
        #endregion

        #region controller hand
        private void ActivateHand()
        {
            if (_controllerInputs.isOnDragging)
            {
                backgroundHand.gameObject.SetActive(true);
            }
            else
            {
                backgroundHand.gameObject.SetActive(false);
            }
        }

        private void MovingHand()
        {
            Vector3 dragging = _controllerInputs.deltaDragging;
            movingHand.position =backgroundHand.position + dragging;
        }
        #endregion
    }
}