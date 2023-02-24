using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gameState = GameState.Play;
    }
    public void StartGame()
    {
        gameState = GameState.Play;
    }
    public enum GameState
    {
        Play,
        Pause
    }
}
