using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    // Start is called before the first frame update
    //public static int count;
    [SerializeField] AudioSource birdSound;
    private void Start() {
        birdSound = GameObject.Find("birdSound").GetComponent<AudioSource>();
        Destroy(transform.parent.gameObject,60);
    }
    public void click(){
        if(!birdSound.isPlaying){
            birdSound.Play();
        }
        FindObjectOfType<scence3>().scoreManage(1);
        Destroy(transform.parent.gameObject);
    }

    

    
}
