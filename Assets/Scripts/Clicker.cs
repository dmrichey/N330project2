using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour{
    bool active = false;
    GameObject note;
    string previous= "Note";

    GameManager gm;
        
    void Start (){
        gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }    
        
        // *if it is a normaL blue note and the previous one is a normal note then it can just be clicked
        // *if the previous was a hold note, then the hold note has to be in the hitbox at the same time the note is for it to count, will be 2 points so do score() twice.
        // *if it is a holdnote and the previous one is normal, then it needs to be grabbed, dont do score just make it draggable.
        // *if the previous was a hold note, then they both go away score() twice.
        
    void OnMouseDown(){
        if(active && note.tag=="Note"){
			Debug.Log("clicked Note");
			Debug.Log(string.Format("previous = {0}", previous));
			// Note->Note if the previous note was a normal note, then it just can be clicked and scored by itself
            if (previous == "Note"){
			Destroy(note);
            gm.Score();
            gm.setPrevious("Note"); 
			}// end  inner if 
			
			/* if the previous note was a holdnote, then it needs to have a holdnote in the same hitbox to count
			then it will count both */
		else if(previous == "HoldNote"){
			//HoldNote -> Note
			/* do not count unless there is a "HoldNote" in the 
			same hitbox that the note is, 2 score()s if it is. */
			gm.setPrevious("Note"); 
				}// end inner eif			
			}//end outer if (Normal note cases)
			
		// these cases are for the current note being a HoldNote
		else if(active && note.tag =="HoldNote"){
            if(previous == "Note"){	
			/* Note->HoldNote if the previous one was a normal note,
			then this note will need to be dragged to a spot with another note */
			
			gm.setPrevious("HoldNote");
			}//end inner if
			
			else if( previous == "HoldNote"){
			//HoldNote -> Note
			// if the previous was a HoldNote, then it has to have a holdnote in the same hitbox
			// they both disspear and both count for points.
				
				
			gm.setPrevious("HoldNote");
			}// end inner eif
			} // end outer eif(HoldNote cases)
    
	
	
	}
        
        /* when a new note enters any of the 4 hitboxes,
        it updates with the previous note clicked from the gm */
    public void OnTriggerEnter2D(Collider2D collision){
		// it will get previous from gm everytime something collides with any of the 4 hitboxes.
		previous = gm.getPrevious();
        if(collision.gameObject.tag == "Note"){
            note = collision.gameObject;
            active = true;
        }if(collision.gameObject.tag == "HoldNote"){
            note = collision.gameObject;
            active = true;
        }
    }
        
    public void OnTriggerExit2D(Collider2D collision){
        active = false;
    }
}