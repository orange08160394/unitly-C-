using UnityEngine;
using System.Collections;

public class Flutter : MonoBehaviour {
    public float speed;     // 往右按鍵速度
    public Vector3 vel;		// 氣泡移動的速度
	public float growthRate;// 氣泡的成長率
	float initSize = .1f;	// 氣泡最初的大小
	Vector3 pos;
	// Use this for initialization
	void Start () {
		// 氣泡最初在原點
		transform.position = Vector3.zero;
		// 以亂數隨機產生氣泡的速度
		vel=new Vector3(Random.Range(0.2f,0.4f),Random.Range(-0.1f,0.1f),0.0f);
        // 根據按鍵速度，調整泡泡移動速度
        vel *= speed;
		// 以亂數隨機產生氣泡的成長率
		growthRate=speed*Random.Range(0.2f,0.35f);
	}
	
	// Update is called once per frame
	void Update () {
		// 根據速度計算氣泡的座標
		Vector3 pos = transform.position;
		pos+= vel;
		transform.position = pos;
		// 根據成長率計算大小
		float size = initSize + pos.x * growthRate;
		transform.localScale = new Vector3 (size, size, size);
	}
}
