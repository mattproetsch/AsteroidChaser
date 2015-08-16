using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {

	public Sprite Star;
	public Sprite Planet;
	public Sprite Galaxy;
	public Sprite Satellite;
	public Sprite StarSystem;

	private Camera _mainCamera;
	private GameObject _playerShip;
	private Move _move;

	private Vector2 _viewportSize;
	private Vector2 _tilesCenter;

	private Sprite[,] _sprites;

	void Start() {
		_mainCamera = Camera.main;
		_playerShip = GameObject.Find ("Ship");
		_move = _playerShip.GetComponent<Move> ();

		UpdateTileSize ();
		GenerateSprites ();
	}

	void Update() {
		if (NeedToGenerate ()) {
			GenerateSprites ();
		}
	}

	bool NeedToGenerate() {
		return true;
	}

	void GenerateSprites () {

		_tilesCenter = _playerShip.transform.position;
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
		GenerateSprites ();
	}
}
