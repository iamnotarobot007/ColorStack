using System;
using System.Collections;
using UnityEngine;


namespace Yudiz.StackColor.GamePlay
{
    public class PickupStackColor : MonoBehaviour
    {
        #region PUBLIC_VARS
        public bool isCollectable = false;
        public int value;
    
        #endregion

        #region PRIVATE_VARS
        
        [SerializeField] Color pickupColor;
        Renderer rend;
        [SerializeField] Rigidbody pickupRB;
        [SerializeField] Collider pickpCollider;

        #endregion

        #region UNITY_CALLBACKS
     
     
        private void Start()
        {
            rend = GetComponent<Renderer>();
            //if (rend != null && rend.material != null)
            //{
            //    rend.material.color = pickupColor;
            //}
        }

        private void OnEnable()
        {
            PlayerController.Color += ColorChange;
            PlayerController.Kick += MyKick;
        }

        private void OnDisable()
        {
            PlayerController.Color -= ColorChange;
            PlayerController.Kick -= MyKick;
        }
        #endregion

        #region PUBLIC_FUNCTIONS
        void ColorChange(Color color)
        {
            if (isCollectable)
            {
                rend.material.color = color;
            }
        }
        #endregion

        #region PRIVATE_FUNCTIONS
        private void MyKick(float forceSent)
        {
            if (isCollectable)
            {
                transform.parent = null;
                pickpCollider.enabled = true;
                pickpCollider.isTrigger = false;
                pickupRB.isKinematic = false;
                pickupRB.AddForce(new Vector3(0, forceSent, forceSent));
                StartCoroutine(ShowGameOverCoroutine());
            }
           
        }
        private IEnumerator ShowGameOverCoroutine()
        {
            yield return new WaitForSeconds(5.0f);
            UIManager.instance.SwitchScreen(ScreenType.GameOver);

          
            ResetGame();

            
           
        }

        public void ResetGame()
        {
           
        }







        #endregion

        #region CO-ROUTINES
        #endregion

        #region EVENT_HANDLERS
        #endregion

        #region UI_CALLBACKS
        #endregion
    }
}

//Color to change,stack to throw