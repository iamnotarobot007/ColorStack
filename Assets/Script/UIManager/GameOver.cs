using UnityEngine;
using Yudiz.StackColor.GamePlay;

public class GameOver : BaseScreen
{
    public GameManager gm;
    #region PUBLIC_FUNCTIONS
   
    public void MainMenu()
    {
        UIManager.instance.SwitchScreen(ScreenType.HomeScreen);
        gm.ResetGame();
    }
    public void Replay()
    {
        UIManager.instance.SwitchScreen(ScreenType.GamePlay);
       
    }

    #endregion

}