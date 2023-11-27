using UnityEngine;
using Yudiz.StackColor.UI;
namespace Yudiz.StackColor.GamePlay
{
    public class Multiplier : MonoBehaviour
    {
        #region PUBLIC_VARS
        #endregion

        #region PRIVATE_VARS
        [SerializeField] float multiplierValue;
        [SerializeField] Color multiplierColor;
        [SerializeField] Renderer[] myRend;
        #endregion

        #region UNITY_CALLBACKS
        private void Start()
        {
            SetColor();
        }
        #endregion

        #region STATIC_FUNCTIONS
        #endregion

        #region PUBLIC_FUNCTIONS

        #endregion

        #region PRIVATE_FUNCTIONS
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.CompareTag("Pickup"))
            {
               ScoreManager.instance.UpdateMultiplier(multiplierValue);
            }
        }
        void SetColor()
        {
            for (int i = 0; i < myRend.Length; i++)
            {
                myRend[i].material.SetColor("_Color", multiplierColor);
            }
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