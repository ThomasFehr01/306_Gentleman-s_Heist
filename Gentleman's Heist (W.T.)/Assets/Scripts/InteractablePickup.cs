using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Simple interaction when a Player interacts with an interactable object.
public class InteractablePickup : MonoBehaviour
{
    //Coin pickup sound
    public AudioSource coinSound;
    //Diamond pickup sound
    public AudioSource diamondSound;
    
    //Instantiating the sound sources
    void Start() {
        coinSound = gameObject.GetComponent<AudioSource>();
        diamondSound = gameObject.GetComponent<AudioSource>();
    }
    /**Does an interaction with a game object that depends on which game object is being interacted with. 
    Key updates number of keys the player has, Diamond updates the number of diamonds a player has and plays audio indicating it was picked up for satisfaction
    Coin updates the score of the player and plays a coin sound when picked up.
    After game object is interacted with, it will be deleted from the scene.
    **/
    public void DoInteraction(string name){
        //This fixes sound being quiet but distorts the clip if player moves while picking up item
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,Camera.main.transform.position.z);
        
        if (name.StartsWith("Key")){
            UIUpdater.keys++;
        }
        else if(name.StartsWith("Diamond")){
            AudioSource.PlayClipAtPoint(diamondSound.clip,position, 1.0f);
            UIUpdater.diamonds++; 
        }
        else if(name.StartsWith("Coin")){
            AudioSource.PlayClipAtPoint(coinSound.clip,position, 1.0f);
            UIUpdater.score++;
        }
        Destroy(gameObject);
    }
}
