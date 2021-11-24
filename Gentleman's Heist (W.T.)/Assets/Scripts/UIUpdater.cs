using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Workable, probably temporary, version of updating keys + score/diamonds text and displaying on a canvas.
public class UIUpdater : MonoBehaviour

{
    [SerializeField]
    private Text keys_text;

    [SerializeField]
    private Text score_text;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        UpdateUIKeys(PlayerData.GetKeys());
        UpdateUIScore(PlayerData.GetScore());
    }
    //Updates the keys text to be the new amount of keys
    public void UpdateUIKeys(int num_keys){
        keys_text.text = "" + num_keys;
    }
     //Updates score text to be coins picked up plus diamonds * whatever we want diamonds to be worth
    public void UpdateUIScore(int new_score){
        score_text.text = "Score: " + new_score;
    }
}
