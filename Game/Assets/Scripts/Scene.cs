using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene: MonoBehaviour {

    public GameState gameState;
    public Transform enterTransform;

    private void Awake() {
        Debug.Log("Scene: Awake - Game State: " + GameManager.Instance.gameState);
    }

    void Start () {
        Debug.Log("Scene: Start - Setting Game State: " + gameState);
        GameManager.Instance.SetGameState(gameState);

        GameManager.Instance.GetPlayer().transform.position = enterTransform.position;
	}
}
