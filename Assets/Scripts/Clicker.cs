using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clicker : MonoBehaviour
{
	bool active = false;
	GameObject note;
	private string previous="Note";

	GameManager gm;
	
	void Start ()
	{
		gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
	}	
	
	// if it is a normaL blue note and the previous one is a normal note then it can just be clicked
	// if the previous was a hold note, then the hold note has to be in the hitbox at the same time the note is for it to count, will be 2 points so do score() twice.
	// if it is a holdnote and the previous one is normal, then it needs to be grabbed, dont do score just make it draggable.
	// if the previous was a hold note, then they both go away score() twice.
	
	void OnMouseDown() {
		if(active && note.tag=="Note") {
			Destroy(note);
			gm.Score();
			gm.setPrevious("Note");
			
		}
		else if(active && note.tag =="HoldNote"){
			gm.setPrevious("HoldNote");
		}
	}  
	
	/* when a new note enters any of the 4 hitboxes,
	it updates with the previous note clicked from the gm */
	public void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Note"){
			previous = gm.getPrevious();
			note = collision.gameObject;
			active = true;
		}
		if(collision.gameObject.tag == "HoldNote"){
			previous = gm.getPrevious();
			note = collision.gameObject;
			active = true;
		}
		
		
	}
	
	public void OnTriggerExit2D(Collider2D collision){
		active = false;
	}



	
	
}