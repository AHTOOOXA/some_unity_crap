using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public void LoadLevel (string levelname){
		SceneManager.LoadScene (levelname);
		GameObject[] allfoodcrates = GameObject.FindGameObjectsWithTag ("FoodCrate");
	}

	void Start () {
		
	}

	void Update () {
		
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
