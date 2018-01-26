using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyprefab;	
	public float width=10f,height= 5f,speed= 5f;
	public float xmin,xmax;
	private bool movRight= true;
	
	
	
	
	// Use this for initialization
	void Start () {
	
	float zDistance= transform.position.z- Camera.main.transform.position.z;
	Vector3 leftMost= Camera.main.ViewportToWorldPoint(new Vector3(0,0,zDistance));
	Vector3 rightMost= Camera.main.ViewportToWorldPoint(new Vector3(1,0,zDistance));
	 
	xmin= leftMost.x;
	xmax= rightMost.x;
	
	 	
		Respawn();
	
	}
	
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {
	
	if(movRight)
	{
		transform.position+= new Vector3 (speed*Time.deltaTime,0,0);
	}
	else
		transform.position+= new Vector3 (-speed*Time.deltaTime,0,0);
		
		
		float rightEdge= transform.position.x + (0.5f*width);
		float leftEdge= transform.position.x - (0.5f*width);
		
		if(xmin>leftEdge )
			movRight=true;
		else if(xmax<rightEdge)
			movRight=false;
	
	
		if(checkIfAllEnemiesDead())
		{
			SpawnUntilFull();
			//Debug.Log("All enemies Dead");
		}
							
	}
	
	bool checkIfAllEnemiesDead()
	{
		foreach( Transform child in transform)
		{
			if(child.childCount>0)
			{
				return false;
			}
		}
		return true;
	}
	
	void SpawnUntilFull()
	{
		Transform nextFreePos= NextFreePosition();
		if(nextFreePos)
		{
			GameObject enemy= Instantiate(enemyprefab, nextFreePos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent= nextFreePos;
		}
		
		if(NextFreePosition())
		{
			Invoke("SpawnUntilFull",1f);
		}
	}
	
	
	Transform NextFreePosition()
	{
		foreach(Transform childPosition in transform)
		{
			if(childPosition.childCount==0)
			{
				return childPosition;
			}
		}
		return null;
	}
	
	void Respawn()
	{
		foreach(Transform child in transform)
		{
			GameObject enemy=  Instantiate(enemyprefab,child.transform.position,Quaternion.identity) as GameObject;
			enemy.transform.parent	= child;
		}	
	}
	

}
