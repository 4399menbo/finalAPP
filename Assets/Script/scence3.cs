using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scence3 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform birdI;
    // public Transform targe;
    

    [SerializeField] int score;

    [SerializeField] Text scoreBar;

    [SerializeField] GameObject bird;
    [SerializeField] Transform birdP;


    //public Transform Pmonster;

    int gold;
    void Start()
    {
        StartCoroutine(Create());
        // int id = PlayerPrefs.GetInt("birdID",0);
        // bird.GetChild(id).gameObject.SetActive(true);
        // targe = bird.GetChild(id);
        gold = PlayerPrefs.GetInt("Gold",10);
    }

    // Update is called once per frame
    void Update()
    {
        if(score>=5){
            PlayerPrefs.SetInt("Gold",gold+score*3);
            
            PlayerPrefs.Save();

            SceneManager.LoadScene("scence1");
        }
    }
    
    public void scoreManage(int s){
        score += s;
        scoreBar.text = score.ToString();
    }
     public void exit(){
        PlayerPrefs.SetInt("Gold",gold);

        PlayerPrefs.Save();

        SceneManager.LoadScene("scence1");
    }

    IEnumerator Create(){
        int x = Random.Range(3,11);
        yield return new WaitForSeconds(x);
        Instantiate(bird,birdI.transform.position,birdI.transform.rotation,birdP);
        StartCoroutine(Create());
    }
}
