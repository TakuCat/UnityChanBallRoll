using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float moveVertical;
	private float moveHorizontal;
	private Rigidbody rb;
	public float speed;

	// Use this for initialization
	void Start () {
		//playerのrigidbodyにアクセスするため
		//GetCommponet<MyClass>利点：デメリット：
		// public Myclass mayclass 変数としてインスペクターでD&D
		// [reqireComponennt(typeof(rigidbody))]:rigidbodyあれよ的な
		//他のgameobjectの参照:gameobject.find:自由、でも重い。名前変わるとわからない
		//gameobject.findwithtag("tag") ある程度軽い、タグ増やすてまかかる
		//public Myclass 変数としてインスペクターでD&D:prefabにするとmissingになる。
		//UnityEngine.Assertions;
		//Assert.Isnull
		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
	    
		// input系はupdate
		//可変式：不定期
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
	}

	void FixedUpdate()
	{
		// 実際に動かすにはFixedUpdate
		//一定のタイミングで呼ばれる。:定期
		//物理運動はfixedupdateでやる
		//fixedupdateではinput呼ばない

		Vector3 movement = new Vector3( moveHorizontal, 0.0f, moveVertical );

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		//ontriggerEnter: isTrigger on
		
		//アイテム
		if ( other.gameObject.CompareTag("Item") ) {
			other.gameObject.SetActive(false);
		}
	}
}
