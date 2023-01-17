using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class scence1 : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    [SerializeField] int Hungry;
    [SerializeField] int Hp;

    [SerializeField] GameObject hungryBar;
    [SerializeField] GameObject HpBar;

    [SerializeField] double preTime;

    public static float timing;

    [SerializeField] int Goldcount;

    [SerializeField] Text Gold_G;
    

    [SerializeField] GameObject[] birdID;


    void Start()
    {
        
        Instantiate(birdID[PlayerPrefs.GetInt("birdID",0)]);

        Hungry = PlayerPrefs.GetInt("birdHungry",5);

        Hp = PlayerPrefs.GetInt("birdHp",5);

        preTime = Convert.ToDouble(PlayerPrefs.GetString("preTime","0"));

        Goldcount = PlayerPrefs.GetInt("Gold",10);

        Gold_G.text = Goldcount.ToString();

        StartCoroutine(waitStart());

        if(preTime != 0){
            double TimeSub = GetSubSeconds(DateTime.Now) - preTime;
            TimeSub =  TimeSub/3600;
            downHungry((int)TimeSub);
            PlayerPrefs.SetString("preTime","0");
        }

        StartCoroutine(Timing());

        
    }

    // Update is called once per frame
    void Update()
    {
        HungryManage();
    }

    IEnumerator waitStart(){
        yield return null;
        for(int i=0;i<Hungry;i++){
            hungryBar.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i <Hp; i++)
        {
            HpBar.transform.GetChild(i).gameObject.SetActive(true);
        }
    }


    public double GetSubSeconds(DateTime a){
        TimeSpan aspan = new TimeSpan(a.Ticks);
        return aspan.TotalSeconds;
    }

    public void downHp(int hp){
        if(Hp-hp>5){
            Hp = 5;
            StartCoroutine(UpBar(HpBar,Hp));
        }
        else if(Hp-hp>0){
            Hp -= hp;
            StartCoroutine(UpBar(HpBar,Hp));
        }
        else{
            Hp  = 0;
            StartCoroutine(UpBar(HpBar,Hp));
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("home");
        }
    }

    public void downHungry(int hungry){
        if(Hungry-hungry>5){
            Hungry = 5;
            StartCoroutine(UpBar(hungryBar,Hungry));
        }
        else if(Hungry-hungry>0){
            Hungry -= hungry;
            StartCoroutine(UpBar(hungryBar,Hungry));
        }
        else{
            Hungry = 0;
            StartCoroutine(UpBar(hungryBar,Hungry));
        }
        
    }

    IEnumerator UpBar(GameObject a,int b){
        for (int i = 0; i < 5; i++)
        {
            if(b>=i+1){
                a.transform.GetChild(i).gameObject.SetActive(true);
            }
            else{
                a.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        yield return null;
    }


    public void ESC(){
        save();

        

        PlayerPrefs.Save();

        //print(1);

        StartCoroutine(Q());
    }

    IEnumerator Q(){
        yield return null;
        Application.Quit();
    }

    IEnumerator Timing(){
        yield return new WaitForSeconds(1);
        timing++;
        StartCoroutine(Timing());
    }

    public void HungryManage(){
        if(Hungry>0){
            if(timing >= 60){
                timing = 0;
                downHungry(1);
                downHp(-1);
            }
        }
        else{
            if(timing >= 10){
                timing = 0;
                downHp(1);
            }
            
        }
        
    }
    public void save(){
        PlayerPrefs.SetString("preTime",GetSubSeconds(DateTime.Now).ToString());
        
        PlayerPrefs.SetInt("birdHungry",Hungry);

        PlayerPrefs.SetInt("birdHp",Hp);

        PlayerPrefs.SetInt("Gold",Goldcount);
    }

    public void loadScene(string s){
        save();
        SceneManager.LoadScene(s);
    }

    public void UpGold(int i){
        Goldcount += i;
        Gold_G.text = Goldcount.ToString();
    }
}
