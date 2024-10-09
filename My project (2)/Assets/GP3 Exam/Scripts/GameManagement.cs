using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = GetComponent<ScoreBoard>();
    }    
}
