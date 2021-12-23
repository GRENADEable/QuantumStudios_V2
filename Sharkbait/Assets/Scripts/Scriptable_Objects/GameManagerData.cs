using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager_Data", menuName = "Managers/GameManagerData")]
public class GameManagerData : ScriptableObject
{
    #region Public Variables
    public enum GameState { Menu, Game, Paused, Dead, Exit };
    public GameState currState = GameState.Menu;
    #endregion

    #region Private Variables

    #endregion

    #region Unity Callbacks

    #endregion

    #region My Functions

    #region Buttons
    public void ChangeLevel(int index) => Application.LoadLevel(index);

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    #endregion

    #region Game States
    public void LockCursor(bool isLocked)
    {
        if (isLocked)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }

    public void VisibleCursor(bool isVisible)
    {
        if (isVisible)
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }

    public void TogglePause(bool isPaused)
    {
        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void ChangeGameState(string state)
    {
        if (state.Contains("Menu"))
            currState = GameState.Menu;

        if (state.Contains("Game"))
            currState = GameState.Game;

        if (state.Contains("Paused"))
            currState = GameState.Paused;

        if (state.Contains("Dead"))
            currState = GameState.Dead;

        if (state.Contains("Exit"))
            currState = GameState.Exit;
    }

    #endregion

    #endregion
}