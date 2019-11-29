using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //Prefabは、public修飾子にしておくことで、スクリプトをアタッチできる
	public GameObject applePrefab;
	public GameObject bombPrefab;
	float span = 1.0f;
	float delta = 0;
	int ratio = 2 ;
	float speed = -0.03f;

    //監督が設計変更を出しやすいようにまとめて書いて、関数化しておく。
	public void SetParameter(float span, float speed, int ratio)
    {
		this.span = span;
		this.speed = speed;
		this.ratio = ratio;
	}


    //以下には、上記の設計変更が随時反映されていく
	void Update()
    {
		this.delta += Time.deltaTime;
		if(this.delta > this.span)
        {
			this.delta = 0;

            //itemとしてりんご、爆弾を共通の変数で管理
            //状況により、applePrefabか、bombPrefabかを使い分ける
			GameObject item;
			int dice = Random.Range(1, 11);
			if(dice <= this.ratio)
            {
				item = Instantiate(bombPrefab) as GameObject;
			}

            else
            {
				item = Instantiate(applePrefab) as GameObject;
			}
			float x = Random.Range(-1, 2);
			float z = Random.Range(-1, 2);
			item.transform.position = new Vector3(x, 4, z);
			item.GetComponent<ItemController>().dropSpeed = this.speed;
            //落ちていくスピードは、アイテムコントローラですでに管理しているので代入する
		}
	}
}