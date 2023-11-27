using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yudiz.StackColor.GamePlay
{
    public class CameraController : MonoBehaviour
    {
        #region PUBLIC_VARS
        public static CameraController instance;

        public Transform cameraTransform;
        public Vector3 initialCameraPosition;
        #endregion

        #region PRIVATE_VARS
        [SerializeField] Transform target;
        float dealtaZ;
        #endregion

        #region UNITY_CALLBACKS

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            dealtaZ = transform.position.z - target.position.z;
        }


        void FixedUpdate()
        {
            if (target != null)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + dealtaZ);
            }
        }
        #endregion

        #region PUBLIC_FUNCTIONS
        public void TurnCamera(Quaternion endvalue, float duration)
        {
            StartCoroutine(LerpFunction(endvalue, duration));
        }

        public void SetTarget(Transform parentPickup)
        {
            target = parentPickup;
        }
        #endregion

        #region CO-ROUTINES
        IEnumerator LerpFunction(Quaternion endValue, float duration)
        {
            float time = 0;
            Quaternion startValue = transform.rotation;
            while (time < duration)
            {
                transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.rotation = endValue;
        }
        #endregion

        public void ResetCamera()
        {
            cameraTransform.position = initialCameraPosition;
        }

    }
}


