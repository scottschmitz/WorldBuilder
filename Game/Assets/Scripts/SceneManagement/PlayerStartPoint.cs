using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    public Vector2 startDirection;
    public string pointName;

    public Location.Point location;

    private PlayerController _player;
    private CameraController _camera;

	void Start () {
        _player = GameManager.Instance.GetPlayer();
        _camera = GameManager.Instance.GetCamera();

        if (GameManager.Instance.GetPlayer().startLocation == location) {
            _player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y, _camera.transform.position.z);

            Debug.Log("Starting PlayerStartPoint: " + pointName + ", position: " + _player.transform.position);
        }
	}
}
