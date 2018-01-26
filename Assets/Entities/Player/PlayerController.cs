using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float playerSpeed=25f,playerHealth=300f;
	public float minx;
	public float maxx;
	public float padding=0.8f;
	public GameObject laser;
	public AudioClip fireSound; 
	public float laserSpeed,fireRate=0.2f;
	public GameObject playerLife;
	public Vector3 Topright;
	int i=0;
	public GameObject[] playerLifes ;

	// Use this for initialization
	void Start () {
		float zdistance= transform.position.z- Camera.main.transform.position.z;
		Vector3 leftMost= Camera.main.ViewportToWorldPoint(new Vector3(0,0,zdistance));
		Vector3 rightMost= Camera.main.ViewportToWorldPoint(new Vector3(1,0,zdistance));
		minx= leftMost.x+padding;
		maxx= rightMost.x-padding;
		float zDistance= transform.position.z- Camera.main.transform.position.z;
		Topright= Camera.main.ViewportToWorldPoint(new Vector3(1,1,zDistance));
		playerLifes= new GameObject[3];
		playerLifes[2]= Instantiate(playerLife,Topright-new Vector3(0.4f,0.4f,0f),Quaternion.identity) as GameObject;
		playerLifes[1]= Instantiate(playerLife,Topright-new Vector3(1.4f,0.4f,0f),Quaternion.identity) as GameObject;			
		playerLifes[0]= Instantiate(playerLife,Topright-new Vector3(2.4f,0.4f,0f),Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.position+= new Vector3 (playerSpeed*Time.deltaTime,0f,0f);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position+= new Vector3 (-playerSpeed*Time.deltaTime,0f,0f);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("Fire",0.00001f,fireRate);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("Fire");
		}
			
		
		
		float restrict = Mathf.Clamp(transform.position.x,minx,maxx);
		transform.position= new Vector3(restrict,transform.position.y,transform.position.z);		
	
	}
	
	void Fire()
	{
		GameObject insLaser;
		insLaser= Instantiate(laser,transform.position+new Vector3(0f,1f,0f),Quaternion.identity) as GameObject;
		insLaser.rigidbody2D.velocity= new Vector3(0,laserSpeed); 
		AudioSource.PlayClipAtPoint(fireSound,transform.position);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile pro= collider.gameObject.GetComponent<Projectile>();
		if(pro)
		{
			playerHealth-= pro.GetDamage();
			pro.Hit();
			Destroy(playerLifes[i]);
			i++;
			Debug.Log("i++ hogya next statement hai");
			if(i==3)
			{
				//LevelManager levelManager= GameObject.Find("LevelManager").GetComponent<LevelManager>();
				//levelManager.LoadLevel("Win Screen");
				Application.LoadLevel("Win Screen");
				Destroy(gameObject); 
			}
			Debug.Log("player hit by enemy Missile");
		}
	}
}
