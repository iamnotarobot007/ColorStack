using UnityEngine;

namespace Yudiz.StackColor.GamePlay
{
    public class ColorWall : MonoBehaviour
    {
        #region PUBLIC_VARS
        public Color newColor;
     
        #endregion

        #region PRIVATE_VARS
        #endregion

        #region UNITY_CALLBACKS
        private void Start()
        {
            Color tempColor = newColor;
            tempColor.a = 0.4f;
            Renderer rend = transform.GetComponent<Renderer>();
            rend.material.SetColor("_Color", tempColor);
        }
        #endregion

        #region PUBLIC_FUNCTIONS
        #endregion

    }
}
//color to set initially for color wall
