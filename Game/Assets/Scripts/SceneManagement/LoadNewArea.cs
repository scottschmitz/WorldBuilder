using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;
    public Location.Point locationToStart;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            // Actual name of the scene
            GameManager.Instance.GetPlayer().startLocation = locationToStart;
            SceneManager.LoadScene(levelToLoad);
        }
    }
}