using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager _instance;
	public Text killsTxt;
	private float killsNum=0;
	public Text lifeTxt;
	private float lifeNum=3;
	public GameObject endPanel;
	public GameObject startPanel;
	// Use this for initialization
	void Awake () {


		if(_instance != null && _instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}

		// Here we save our singleton instance
		_instance = this;

		// Furthermore we make sure that we don't destroy between scenes (this is optional)
		DontDestroyOnLoad(gameObject);

		endPanel.SetActive(false);
		startPanel.SetActive(true);
		Time.timeScale=0;
	}

	public void changeKillsText(){
		killsNum++;
		killsTxt.text="Kills:"+killsNum;
	}

	public void changeLives(){
		if(lifeNum>0){
			lifeNum--;

		}else{
			stopGame();
		}
		lifeTxt.text="Life:"+lifeNum;
	}

	private void stopGame(){
		Time.timeScale=0;
		endPanel.SetActive(true);
	}

	public void resetScene(){
		Time.timeScale=1;
		lifeNum=3;
		killsNum=0;
		endPanel.SetActive(false);
	}

	public void startGame(){
		Time.timeScale=1;
		startPanel.SetActive(false);
	}

}
