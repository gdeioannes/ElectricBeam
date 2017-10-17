using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float movementSpeed=0;
	public ParticleSystem particle;
	public ParticleSystem particleSpark;
	public GameObject explode;



	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag=="GameStageBoundary"){
			destroyBullet();
		}
	}

	public void destroyBullet(){
		GameObject myExplode=Instantiate(explode);
		myExplode.transform.position=gameObject.transform.position;

		Destroy(gameObject);
	
	}

	public void destroySpark(){
		
		Destroy(particleSpark);
	}

	public float MovementSpeed {
		get {
			return movementSpeed;
		}
		set {
			movementSpeed = value;
			gameObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * movementSpeed) ;	
		}
	}

}
