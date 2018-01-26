using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 150f,missileSpeed=2f;
	public GameObject enemyMissile;
	public float shotsPerSeconds= 0.5f;
	public int scoreAmount=150;
	private ScoreKeep scoreKeep;
	public AudioClip laserSound,enemyDie;
	

	// Use this for initialization
	void Start () {
	
	scoreKeep=GameObject.Find("Score").GetComponent<ScoreKeep>();
	
	}
	
	// Update is called once per frame
	void Update () {
		float probability=Time.deltaTime*shotsPerSeconds;
		if(Random.value<probability){
			Fire();
		}
	}
	
	
	
	void Fire()
	{
		GameObject enemyMis= Instantiate(enemyMissile,transform.position,Quaternion.identity)as GameObject;
		enemyMis.rigidbody2D.velocity= new Vector3(0f,-missileSpeed,0f);
		AudioSource.PlayClipAtPoint(laserSound,transform.position);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile pro= col.gameObject.GetComponent<Projectile>();
		if(pro)
		{
			health-= pro.GetDamage();
			pro.Hit();
			if(health<=0)
			{
				Destroy(gameObject);
				scoreKeep.Score(scoreAmount);
				AudioSource.PlayClipAtPoint(enemyDie,transform.position);
			}
			Debug.Log("hit by pro");
		}
	}
}
