using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    
    MainMenu,
    GamePlay,
    Puased,

}

public class GameStateManager : MonoBehaviour
{
    public SpiningObject spiningSpeed;

    public Button button;

    public UIManager uiManager;

    public GameState currentState { get; private set; }

    [Header("Debug(read only)")]
    [SerializeField] string currentActiveState;
    

    private void Start()
    {
        SetState(GameState.MainMenu);
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        
        currentState = newState;
        currentActiveState = currentState.ToString();
        OnGameStateChanged(currentState);
    }

    private void OnGameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.MainMenu:

                Debug.Log("GameState changed to MainMenu");
                uiManager.ShowMenu();
                break;

            case GameState.GamePlay:

                Debug.Log("GameState changed to GamePlay");
                Time.timeScale = 1f;
                spiningSpeed.speed = 20f;
                button.enabled = true;
                uiManager.ShowGamePlay();

                break;

            case GameState.Puased:

                Debug.Log("GameState changed to Paused");
                Time.timeScale = 0;
                spiningSpeed.speed = 0f;
                button.enabled = false;
                uiManager.ShowPaused();

                break;

            default:
                break;
        }

    }

    public void StartGame()
    {
        SetState(GameState.GamePlay);
    }
    public void StartMenu()
    {
        SetState(GameState.MainMenu);
    }
    public void Pause()
    {
        if (currentState == GameState.Puased)
        {
            // resume game
            if (currentState == GameState.GamePlay) return;
            SetState(GameState.GamePlay);

        }
        else if (currentState == GameState.GamePlay)
        {
            // pause
            if (currentState == GameState.Puased) return;
            SetState(GameState.Puased);
        }


    }
    
}
