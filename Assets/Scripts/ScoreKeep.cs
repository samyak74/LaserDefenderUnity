using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreKeep : MonoBehaviour {

 	public static int score=0;
 	private Text mYtext;
	public void Score (int points)
	{
		score += points;
		mYtext.text=score.ToString();
	}
	public static void reset(){
		score=0;
		//mYtext.text=score.ToString();
	}
	
	void Start()
	{
			mYtext=GetComponent<Text>();
			reset();
	}
	
}
