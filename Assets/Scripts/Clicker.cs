using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clicker : MonoBehaviour
{
	bool active = false;
	GameObject note;
	public int points;
	public Text pointsText;
	
	void Start ()
	{
		points = 0;
		setPointText();	
	}
	
	
		void OnMouseDown(){
		if(active == true){
			Destroy(note);
			points++;
			setPointText();
		}}        
    
	
	public void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag =="Note"){
			Debug.Log("Cross");
			note = collision.gameObject;
			active = true;
		}
	}
	
	 public void OnTriggerExit2D(Collider2D collision){
		active = false;
	}



	void setPointText()
	{
		pointsText.text = "points:" + points.ToString ();
	}
	
}