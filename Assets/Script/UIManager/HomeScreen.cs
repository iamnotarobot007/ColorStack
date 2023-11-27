using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yudiz.StackColor.GamePlay;

public class HomeScreen : BaseScreen
{
    #region PUBLIC_VARS
    public int _TurnDuration;
    public int _rotateCam = 10;
    #endregion


    #region PUBLIC_FUNCTIONS
    public void StartGame()
    {
        UIManager.instance.SwitchScreen(ScreenType.GamePlay);
      
        CameraController.instance.TurnCamera(Quaternion.Euler(10, -20, 0), _TurnDuration);
    }
    #endregion
}