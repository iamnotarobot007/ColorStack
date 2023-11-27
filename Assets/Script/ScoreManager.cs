using UnityEngine;
using UnityEngine.UI;


namespace Yudiz.StackColor.UI
{
    public class ScoreManager :MonoBehaviour
    {
        #region PUBLIC_VARS
        public static ScoreManager instance;
        #endregion

        #region PRIVATE_VARS
        [SerializeField] Text scoreDisplay;
        int score;
        float multiplerValue;

        #endregion

        #region UNITY_CALLBACKS
        void Awake()
        {
            instance = this;
        }

        #endregion

        #region STATIC_FUNCTIONS
        #endregion

        #region PUBLIC_FUNCTIONS
        public void ScoreUpdate(int valueIn)
        {
            score += valueIn;
            scoreDisplay.text = score.ToString();


        }
        public void UpdateMultiplier(float valueIn)
        {
            if (valueIn <= multiplerValue)
            {
                return;
            }
            multiplerValue = valueIn;
            scoreDisplay.text = (score * multiplerValue).ToString();
        }
        #endregion

        #region PRIVATE_FUNCTIONS
        #endregion

        #region CO-ROUTINES
        #endregion

        #region EVENT_HANDLERS
        #endregion

        #region UI_CALLBACKS
        #endregion
    }
}