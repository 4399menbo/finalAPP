using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class birdMangae : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator ani_;
    [SerializeField] string[] birdState = {"sing","ruffle"};

    [SerializeField] Text birdName;
    Transform goldParent;
    [SerializeField] GameObject goldPartic;

    [SerializeField] AudioSource birdSound;
    void Start()
    {
        birdSound = GameObject.Find("birdSound").GetComponent<AudioSource>();
        goldParent = GameObject.Find("goldparent").transform;
        birdName.text = PlayerPrefs.GetString("birdName","鳥");
    }

    // Update is called once per frame
    
    public void playerToch(){
        if(!birdSound.isPlaying){
            birdSound.Play();
        }

        int x = Random.Range(0,2);

        ani_.SetTrigger(birdState[x]);

        x = Random.Range(0,10);
        if(x == 0){
            FindObjectOfType<scence1>().UpGold(1);
            if(goldParent.childCount == 0){
                Instantiate(goldPartic,new Vector3(0,0,0),Quaternion.identity,goldParent);
            }
        }
    }
}
