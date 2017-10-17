using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;

public class InputManager : MonoBehaviour {

	public bool magnetDetectionEnabled = true;

	// Use this for initialization
	void Start () {

		CardboardMagnetSensor.SetEnabled(magnetDetectionEnabled);
		// Disable screen dimming:
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}
		
	// Update is called once per frame
	void Update () {

		if (!magnetDetectionEnabled) return;

		if (CardboardMagnetSensor.CheckIfWasClicked()) {
			Debug.Log("DO SOMETHING HERE");  // PERFORM ACTION.
			MachineGunController._instance.vrShootBullet();
			CardboardMagnetSensor.ResetClick();
		}

		if(Input.GetButtonDown("Fire1")){
			MachineGunController._instance.vrShootBullet();
		}

	}

}

