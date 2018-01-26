using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText= GetComponent <Text>();
		myText.text= ScoreKeep.score.ToString();
		ScoreKeep.reset();	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
