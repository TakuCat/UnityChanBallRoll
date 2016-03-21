using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		//this.transform.position = player.transform.position + offset;
	}

	void LateUpdate(){
		//Updateの次に呼ばれるもの
		this.transform.position = player.transform.position + offset;
	}


}
