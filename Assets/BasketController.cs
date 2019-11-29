using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

	public AudioClip appleSE;
	public AudioClip bombSE;
    //publicにすることで、音楽ファイルをアタッチできる
	AudioSource aud;
	GameObject director;

	void Start()
    {
        //以下でGetComponentで使用したいから、スタートにて探しておく
        this.director = GameObject.Find("GameDirector");
		this.aud = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
       //otherは、りんご　または　爆弾
    {
		if(other.gameObject.tag == "Apple")
        {
            //衝突検知の動作は、あくまでバスケットコントローラの仕事
            this.director.GetComponent<GameDirector>().GetApple();
			this.aud.PlayOneShot(this.appleSE);
		}

        else
        {
			this.director.GetComponent<GameDirector>().GetBomb();
			this.aud.PlayOneShot(this.bombSE);
		}
		Destroy(other.gameObject);
	}

	void Update()
    {
		if(Input.GetMouseButtonDown(0))
        {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
            //オブジェクトとの衝突を検知する
			if(Physics.Raycast(ray, out hit, Mathf.Infinity)
                レイがあって、レイキャストがあって、検知範囲は無限大、の条件がそろったとき、
            {
				float x = Mathf.RoundToInt(hit.point.x);
				float z = Mathf.RoundToInt(hit.point.z);
				transform.position = new Vector3(x, 0, z);
                //バスケットの動き
			}
		}
	}
}