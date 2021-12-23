using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMenu : MonoBehaviour
{
    #region Serialized Variables

    #region Datas
    [Space, Header("Datas")]
    public GameManagerData gmData;
    #endregion

    #region Audio
    [Space, Header("Audio")]
    [SerializeField] private AudioSource oneShotSFX;
    [SerializeField] private AudioSource bgSFX;
    [SerializeField] private AudioClip[] sfxClips;
    #endregion

    [SerializeField] private Animator fadeBG;
    [SerializeField] private Button[] menuButtons;

    #endregion

    #region Private Variables
    private bool _isFadingMusic;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        fadeBG.Play("FadeIn");
        gmData.ChangeGameState("Menu");
    }

    void Update()
    {
        if (_isFadingMusic)
            bgSFX.volume -= Time.deltaTime;
    }
    #endregion

    #region My Functions
    public void OnClick_StartGame() => StartCoroutine(StartGameDelay());

    public void OnClick_ExitGame() => StartCoroutine(ExitGameDelay());
    public void OnClick_TutsGame() => StartCoroutine(StartTutsGameDelay());

    void DisableButtons()
    {
        for (int i = 0; i < menuButtons.Length; i++)
            menuButtons[i].interactable = false;
    }

    #region Cursor
    void EnableCursor()
    {
        gmData.VisibleCursor(true);
        gmData.LockCursor(false);
    }

    void DisableCursor()
    {
        gmData.VisibleCursor(false);
        gmData.LockCursor(true);
    }
    #endregion

    #endregion

    #region Coroutines
    IEnumerator StartGameDelay()
    {
        fadeBG.Play("FadeOut");
        DisableButtons();
        DisableCursor();
        _isFadingMusic = true;
        yield return new WaitForSeconds(1f);
        gmData.ChangeGameState("Game");
        gmData.ChangeLevel(1);
    }

    IEnumerator StartTutsGameDelay()
    {
        fadeBG.Play("FadeOut");
        DisableButtons();
        DisableCursor();
        _isFadingMusic = true;
        yield return new WaitForSeconds(1f);
        gmData.ChangeGameState("Game");
        gmData.ChangeLevel(2);
    }

    IEnumerator ExitGameDelay()
    {
        fadeBG.Play("FadeOut");
        DisableButtons();
        DisableCursor();
        _isFadingMusic = true;
        yield return new WaitForSeconds(1f);
        gmData.ChangeGameState("Exit");
        gmData.QuitGame();
    }
    #endregion
}