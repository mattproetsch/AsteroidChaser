using UnityEngine;
using System.Collections;

public class AsteroidValue : MonoBehaviour {

	private AsteroidMovement _mvt;
	private int _Value;
	public int Value {
		get {
			return _Value;
		}
	}

	public void Start () {
		_mvt = gameObject.GetComponent<AsteroidMovement> ();
		_Value = (int)(_mvt.Speed * 450.0f);
	}

	public int Extract() {
		int ret = _Value;
		_Value = 0;
		return ret;
	}
}
