using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public BaseScreen[] screen;
    public BaseScreen CurrentScreen;
    public static UIManager instance;
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        instance = this;
        CurrentScreen.canvas.enabled = true;
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void SwitchScreen(ScreenType screenType)
    {
        CurrentScreen.canvas.enabled = false;
        foreach (BaseScreen baseScreen in screen)
        {
            if (baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                CurrentScreen = baseScreen;
                break;
            }

        }
    }
    #endregion

}