using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar : MonoBehaviour {

	public GameObject marker;
	public GameObject enemyContainer;
	public GameObject radarContainer;
	public GameObject radaImg;
	private List<GameObject> markerList = new List<GameObject>();
	private List<GameObject> enemyList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		foreach (Transform child in enemyContainer.transform){
			GameObject markerInst=Instantiate(marker);
			markerInst.transform.localPosition=new Vector3(0,0,0);
			markerInst.transform.parent=radarContainer.transform;
			markerList.Add(markerInst);
			enemyList.Add(child.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion radImgTrans=radaImg.transform.rotation;
		radaImg.transform.rotation=Quaternion.Euler(new Vector3(radImgTrans.x,radaImg.transform.rotation.y,Camera.main.transform.rotation.z));
		for(int enemyNum=0;enemyNum<enemyList.Count;enemyNum++){
			Transform enemyTransform=enemyList[enemyNum].transform;
			markerList[enemyNum].transform.localPosition=new Vector3(enemyTransform.position.x,enemyTransform.position.y,0)*50;
		}
	}
}
