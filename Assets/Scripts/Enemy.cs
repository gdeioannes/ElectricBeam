using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Transform startMarker;
	public Transform endMarker;
	private float speed = 0.02F;
	private float startTime;
	private float journeyLength;
	public  GameObject particleExplode;

	// Use this for initialization
	void Awake () {
		setParamenters();
	}

	private void setParamenters(){
		startMarker=gameObject.transform;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.timeScale>0){
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="EndMarker"){
			GameObject part=Instantiate(particleExplode);
			part.transform.position=transform.position;
			repoEnemy();
			SoundManager._instance.playEnemy();

			UIManager._instance.changeLives();
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag=="Bullet"){
			other.gameObject.GetComponent<Bullet>().destroyBullet();
			repoEnemy();
			SoundManager._instance.playExplode();
			UIManager._instance.changeKillsText();
		}
	}

	void repoEnemy(){
		transform.position=new Vector3(randomPosition(),5+Random.Range(2,1),randomPosition());
		setParamenters();
	}

	private float randomPosition(){
		if(Random.Range(1,10)>5){
			return 10+Random.Range(10,15);
		}else{
			return -10-Random.Range(10,15);
		}
		return 10f;
	}
		

}
