using UnityEngine;
using Yudiz.StackColor.GamePlay;

public class GameManager : MonoBehaviour
{
    public PlayerController ps;
    public StackSpawner cs;
    public CameraController cc;

    public void ResetGame()
    {
        ps.ResetPlayer();
        cs.DestroySpawnedCubes();
        cc.ResetCamera();
    }
}
