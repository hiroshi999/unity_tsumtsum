using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockManager : MonoBehaviour {

	// blockプレハブを設定
	public GameObject block;

	// テクスチャを指定
	public Sprite[] blockSprites;

	// 初期の出現ブロック数
	public int block_num = 40;

	// 出現するx軸の範囲
	public float drop_pos_range_x = 2.0f;

	// 出現するy軸の範囲
	public float drop_pos_y = 1.5f;

	// 直前にクリックしたブロック
	private GameObject firstBlock;

	// 直前にクリックしたブロック
	private GameObject lastBlock;

	// 現在のブロック名
	private string currentName;

	// 削除するブロックリスト
	List<GameObject> removeBlockList = new List<GameObject>();

	// 効果音
	private PlaySound playSound;

	// スコア
	public int point = 100;

	// クリアスコア
	public int clear_point = 2000;

	// Use this for initialization
	void Start () {
		// 効果音を取得
		GameObject se = GameObject.Find("SE");
		playSound = se.GetComponent<PlaySound>();
		//playSound.PlaySe00 ();
		DropBlock (block_num);
	}
	
	// Update is called once per frame
	void Update () {
		//removeBlockList = new List<GameObject>();
		if (Input.GetMouseButton (0) && firstBlock == null) {
			OnClickFirst ();
		} else if (Input.GetMouseButton (0) && firstBlock) {
			OnClicking ();
		} else if (Input.GetMouseButtonUp(0) && firstBlock) {
			OnClickEnd ();
		}
	}

	// ブロックを出現させる
	private void DropBlock(int count){
	
		for (int i = 0; i < count; i++) {
			// ポジションを取得
			Vector3 position = block.transform.position;
			position.x = Random.Range(position.x - drop_pos_range_x, position.x + drop_pos_range_x);
			position.y = drop_pos_y;

			// テクスチャの変更
			int spriteId = Random.Range(0, 8);
			block.name = "block_sprite_" + spriteId;
			SpriteRenderer spriteObj = block.GetComponent<SpriteRenderer>();
			//Debug.Log (spriteObj.sprite);
			spriteObj.sprite = blockSprites[spriteId];

			Instantiate (block, position, block.transform.rotation);
		}
	}

	// クリックした時の処理
	private void OnClickFirst(){
		// クリックしたオブジェクト取得
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		//Debug.Log (hit.collider);
		if (hit.collider != null) {
			//Debug.Log (hit.collider.gameObject.name);
			GameObject hitObj = hit.collider.gameObject;

			// オブジェクト名を前方一致で判定
			string stTarget = hitObj.name;
			if (stTarget.StartsWith("block_sprite_")) {
				//Debug.Log ("Block First Hit => " + stTarget);

				// 音を鳴らす
				playSound.PlaySe00 ();

				firstBlock  = hitObj;
				lastBlock   = hitObj;
				currentName = hitObj.name;

				// 削除対象のオブジェクトを格納
				removeBlockList = new List<GameObject>();
				removeBlockList.Add (hitObj);
			}
		}
	}

	// クリックしている途中の処理
	private void OnClicking(){
		// クリックしたオブジェクト取得
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		//Debug.Log (hit.collider);
		if (hit.collider != null) {
			//Debug.Log (hit.collider.gameObject.name);
			GameObject hitObj = hit.collider.gameObject;

			// 同じブロックをクリックしている時
			if (hitObj.name == currentName && lastBlock != hitObj) {
				float distance = Vector2.Distance(hitObj.transform.position, lastBlock.transform.position);
				if (distance < 1.0f) {
					Debug.Log ("Remove Block Add");

					// 音を鳴らす
					playSound.PlaySe00 ();

					// 削除対象のオブジェクトを格納
					lastBlock = hitObj;
					removeBlockList.Add (hitObj);
				}
			}
		}
	}

	// クリックをはなした時の処理
	private void OnClickEnd(){
		int remove_cnt = removeBlockList.Count;
		Debug.Log ("Remove Count => " + remove_cnt);
		if (remove_cnt >= 3) {
			for (int i = 0; i < remove_cnt; i++) {
				Destroy (removeBlockList[i]);
			}

			// ブロック削除時の音
			PlaySe (remove_cnt);

			// スコアの加算
			FindObjectOfType<Score>().AddPoint(point * remove_cnt);

			// クリア判定
			int currentPoint = FindObjectOfType<Score> ().GetPoint ();
			if (currentPoint >= clear_point) {
				FindObjectOfType<Manager>().GameClear();
			}

			// ボール新たに生成
			DropBlock (remove_cnt);
		}
		firstBlock = null;
		lastBlock  = null;
	}

	// ブロック削除時の音を鳴らす
	private void PlaySe(int cnt){
		if (cnt == 3) {
			playSound.PlaySe01 ();
			playSound.PlaySe02 ();
			playSound.PlaySe03 ();
		} else if (cnt == 4) {
			playSound.PlaySe01 ();
			playSound.PlaySe02 ();
			playSound.PlaySe03 ();
			playSound.PlaySe04 ();
		} else if (cnt == 5) {
			playSound.PlaySe01 ();
			playSound.PlaySe02 ();
			playSound.PlaySe03 ();
			playSound.PlaySe04 ();
			playSound.PlaySe05 ();
		}
	}
		
}