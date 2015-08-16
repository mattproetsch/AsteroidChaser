using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTiles : MonoBehaviour {

	public GameObject Star;
	public GameObject Planet;
	public GameObject Galaxy;
	public GameObject Satellite;
	public GameObject StarSystem;

	private Camera _mainCamera;
	private GameObject _playerShip;
	private Move _move;

	private Vector2 _viewportSize;
	private Vector2 _tilesCenter;

	private List<GameObject> _sprites;

	void Start() {
		_mainCamera = Camera.main;
		_playerShip = GameObject.Find ("Ship");
		_move = _playerShip.GetComponent<Move> ();

		_sprites = new List<GameObject> ();
		UpdateTileSize ();
		GenerateSprites ();
		PositionSpritesInitial ();
	}

	void Update() {
		if (NeedToRepositionSprites ()) {
			RepositionSprites ();
		}
	}

	bool NeedToRepositionSprites() {
		Vector3 shipPos = _playerShip.transform.position;
		return shipPos.x < _tilesCenter.x - _viewportSize.x ||
				shipPos.x > _tilesCenter.x + _viewportSize.x ||
				shipPos.y < _tilesCenter.y - _viewportSize.y || 
				shipPos.y > _tilesCenter.y + _viewportSize.y;
	}

	void GenerateSprites () {
		_tilesCenter = _playerShip.transform.position;
		Rect viewRect = GetCameraGameBounds ();

		for (int i = 0; i < 500; i++) {
			GameObject sprite = GameObject.Instantiate(Star) as GameObject;
			_sprites.Add (sprite);
		}

		Debug.Log ("Generated " + _sprites.Count + " sprites");
	}

	void RepositionSprites() {
		Debug.Log ("Repositioning sprites:");
		Vector3 shipPos = _playerShip.transform.position;

		if (shipPos.x < _tilesCenter.x - _viewportSize.x) {
			// Reposition sprites to the right of shipPos.x + _viewportWidth/2
			Debug.Log ("     Because ship moved left");
			List<GameObject> repositionUs = _sprites.FindAll(sprite => sprite.transform.position.x > shipPos.x + _viewportSize.x);
			Debug.Log (repositionUs.Count + " sprites to be moved");
			float xMin = shipPos.x - 1.5f * _viewportSize.x;
			float xMax = shipPos.x - 0.5f * _viewportSize.x;
			Debug.Log ("Reposition sprites with x in [" + xMin + ", " + xMax + "]");
			foreach (GameObject go in repositionUs) {
				go.transform.position = new Vector3(Random.Range (xMin, xMax), go.transform.position.y, Random.Range(10, 20));
			}
			_tilesCenter.x = shipPos.x;
		}
		else if (shipPos.x > _tilesCenter.x + _viewportSize.x) {
			Debug.Log ("     Because ship moved right");
			// Reposition sprites to the left of shipPos.x - _viewportWidth/2
			List<GameObject> repositionUs = _sprites.FindAll(sprite => sprite.transform.position.x < shipPos.x - _viewportSize.x);
			Debug.Log (repositionUs.Count + " sprites to be moved");
			float xMin = shipPos.x + 0.5f * _viewportSize.x;
			float xMax = shipPos.x + 1.5f * _viewportSize.x;
			Debug.Log ("Reposition sprites with x in [" + xMin + ", " + xMax + "]");
			foreach (GameObject go in repositionUs) {
				go.transform.position = new Vector3(Random.Range (xMin, xMax), go.transform.position.y, Random.Range (10, 20));
			}
			_tilesCenter.x = shipPos.x;
		}

		if (shipPos.y > _tilesCenter.y + _viewportSize.y) {
			Debug.Log ("     Because ship moved up");
			// REposition sprites below _shipPos.y - _viewportWidth/2
			List<GameObject> repositionUs = _sprites.FindAll(sprite => sprite.transform.position.y < shipPos.y - _viewportSize.y);
			Debug.Log (repositionUs.Count + " sprites to be moved");
			float yMin = shipPos.y + 0.5f * _viewportSize.y;
			float yMax = shipPos.y + 1.5f * _viewportSize.y;
			Debug.Log ("Reposition sprites with y in [" + yMin + ", " + yMax + "]");
			foreach (GameObject go in repositionUs) {
				go.transform.position = new Vector3(go.transform.position.x, Random.Range (yMin, yMax), Random.Range (10, 20));
			}
			_tilesCenter.y = shipPos.y;
		}
		else if (shipPos.y < _tilesCenter.y - _viewportSize.y) {
			Debug.Log ("     Because ship moved down");
			// REposition sprites above _shipPos.y + _iweportWidth/2
			List<GameObject> repositionUs = _sprites.FindAll(sprite => sprite.transform.position.y > shipPos.y + _viewportSize.y);
			Debug.Log (repositionUs.Count + " sprites to be moved");
			float yMin = shipPos.y - 1.5f * _viewportSize.y;
			float yMax = shipPos.y - 0.5f * _viewportSize.y;
			Debug.Log ("Reposition sprites with y in [" + yMin + ", " + yMax + "]");
			foreach (GameObject go in repositionUs) {
				go.transform.position = new Vector3(go.transform.position.x, Random.Range (yMin, yMax), Random.Range (10, 20));
			}
			_tilesCenter.y = shipPos.y;
		}
	}

	void PositionSpritesInitial() {
		Vector3 shipPos = _playerShip.transform.position;
		float yMin = shipPos.y - 1.5f * _viewportSize.y;
		float yMax = shipPos.y + 1.5f * _viewportSize.y;
		float xMin = shipPos.x - 1.5f * _viewportSize.x;
		float xMax = shipPos.x + 1.5f * _viewportSize.x;
		for (int i = 0; i < 500; i++) {
			_sprites [i].transform.position = new Vector3 (Random.Range (xMin, xMax), Random.Range (xMin, xMax), Random.Range (10, 20));
		}
	}

	Rect GetCameraGameBounds() {
		Vector3 bottomLeftBounds = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
		Vector3 topRightBounds = _mainCamera.ViewportToWorldPoint (new Vector3 (1, 1));
		
		Debug.Log ("Bottom left: " + bottomLeftBounds.ToString ());
		Debug.Log ("Top right: " + topRightBounds.ToString());
		
		
		return new Rect (bottomLeftBounds, topRightBounds - bottomLeftBounds);
	}

	void UpdateTileSize ()
	{
		Rect r = GetCameraGameBounds ();
		_viewportSize = new Vector2 (r.width, r.height);
	}

	void ViewportChanged()
	{
		UpdateTileSize ();
		RepositionSprites ();
	}
}
