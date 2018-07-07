using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum GameState { Game, PauseMenu }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {

    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    private static GameManager _instance;
    private static HUD _hud;
    private static PlayerController _player;

    public static GameManager Instance {
        get {
            // if we do not have an instance already, lets look to see
            // if one has already been created for us
            if (_instance == null) {
                _instance = Object.FindObjectOfType<GameManager>();
            }

            // If we still dont have an instance, it must not exist,
            // so lets create our own and prevent it from being deleted
            // when the level changes
            if (_instance == null) {
                GameObject go = new GameObject("_GameManager");
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<GameManager>();

                // Before we start creating the UI lets create the event system
                // This would happen naturally by adding a Canvas through the UI)
                GameObject eventSystem = new GameObject("_EventSystem");
                eventSystem.AddComponent<EventSystem>();
                eventSystem.AddComponent<StandaloneInputModule>();
                DontDestroyOnLoad(eventSystem);

                // Now lets just create our blank canvas, that all of our GUI will be a part of
                GameObject gui = (GameObject)Instantiate(Resources.Load("GUI/MainCanvas"), new Vector3(), Quaternion.identity);
                gui.name = "_GUI";
                DontDestroyOnLoad(gui);

                _hud = HUD.Instance;
                if (_hud == null) {
                    Debug.LogError("Failed to Instantiate HUD");
                }

                _player = Object.FindObjectOfType<PlayerController>();
                if (_player == null) {
                    GameObject playerObj = (GameObject) Instantiate(Resources.Load("Player"), new Vector3(), Quaternion.identity);
                    _player = playerObj.GetComponent<PlayerController>();
                    _player.inventory = _hud.GetInventory();
                    DontDestroyOnLoad(_player);
                }
            }

            return _instance;
        }
    }

    /*
    * Update the Game State and call any Game State Change Handlers that have
    * been added
    **/
    public void SetGameState(GameState aGameState) {
        if (gameState != aGameState) {
            gameState = aGameState;

            if (OnStateChange != null) {
                OnStateChange();
            }
        }
    }

    public PlayerController GetPlayer() {
        return _player;
    }

    /*
     * Sample implementation of an OnStateChangeHandler 
     */
    private static void OnGameStateChange() {
        if (_instance.gameState == GameState.Game) {
            Debug.Log("Changing timeScale from: " + Time.timeScale);
            Time.timeScale = 1;
        } else if (_instance.gameState == GameState.PauseMenu) {
            Debug.Log("Changing timeScale from: " + Time.timeScale + " to 0");
            Time.timeScale = 0;
        }
    }
}
