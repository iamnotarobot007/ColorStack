using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    HomeScreen,GamePlay,GameOver
}

public class BaseScreen : MonoBehaviour
{
    #region PUBLIC_VARS
    public ScreenType screenType;
    [HideInInspector]
    public Canvas canvas;
    #endregion

    #region UNITY_CALLBACKS
    public void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    #endregion

}