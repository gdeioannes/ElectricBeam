using UnityEngine;
using System.Collections;

public class MachineGunController : MonoBehaviour {

	public static MachineGunController _instance;

	public GameObject bullet;
	private GameObject myBullet;
	private bool putBulletFlag=false;
	private float chargeSpeed=3;
	public GameObject shootMarker;
	public GameObject endMarker;

	private SoundManager soundManager;

	void Awake(){
		if(_instance != null && _instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}

		// Here we save our singleton instance
		_instance = this;

		// Furthermore we make sure that we don't destroy between scenes (this is optional)
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(soundManager==null){
			soundManager=SoundManager._instance;
		}

		if(Input.GetKeyDown(KeyCode.Space) ){
			chargeBullet();
		}

		if(Input.GetKeyUp(KeyCode.Space)){
			shootBullet();
		}
			

	}

	public void chargeBullet(){
		createBullet();
	}

	void createBullet(){
		if(!putBulletFlag){
			myBullet= Instantiate(bullet);
			myBullet.transform.parent=shootMarker.transform;
			myBullet.transform.rotation=shootMarker.transform.rotation;
			myBullet.transform.position=shootMarker.transform.position;
			putBulletFlag=true;
		}
	}

	public void shootBullet(){
		putBulletFlag=false;
		if(soundManager!=null){
			soundManager.playFire();
		}
		myBullet.GetComponent<Bullet>().MovementSpeed=1600;
		myBullet.GetComponent<Bullet>().destroySpark();
		myBullet.transform.parent=null;
	}

	public void vrShootBullet(){

		myBullet= Instantiate(bullet);
		myBullet.transform.rotation=shootMarker.transform.rotation;
		myBullet.transform.position=shootMarker.transform.position;
		myBullet.transform.parent=shootMarker.transform;
		shootBullet();

	}



}
