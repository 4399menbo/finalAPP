using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject play_btn;
    [SerializeField] GameObject Sel_Game_btn;
    [SerializeField] GameObject Sel_Bird_btn;

    [SerializeField] GameObject Sel_Name_btn;
    [SerializeField] GameObject[] page;

    [SerializeField] Text Sel_Bird_Info;

    //public string[] bird = {"bird1","bird2","bird3"};
    

    [SerializeField] InputField InputName;

    int n=0;


    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play(){
        play_btn.SetActive(false);
        Sel_Game_btn.SetActive(true);
    }

    public void New_Game(){
        Sel_Game_btn.SetActive(false);
        Sel_Bird_btn.SetActive(true);
        page[0].SetActive(true);
        Sel_Bird_Info.text = "選擇鳥類\n當前鳥類:冠藍鴉";
        n=0;
    }
    public void previous(){
        if(n == 0){
            page[2].SetActive(true);
            page[0].SetActive(false);
            Sel_Bird_Info.text = "選擇鳥類\n當前鳥類:知更鳥";

            n = 2;
        }
        else if(n == 1){
            page[0].SetActive(true);
            page[1].SetActive(false);
            Sel_Bird_Info.text = "選擇鳥類\n當前鳥類:冠藍鴉";

            n = 0;
        }
        else if(n == 2){
            page[1].SetActive(true);
            page[2].SetActive(false);
            Sel_Bird_Info.text = "選擇鳥類\n當前鳥類:北美紅雀";

            n = 1;
        }
    }
    public void Next(){
        if(n == 0){
            page[1].SetActive(true);
            page[0].SetActive(false);
            Sel_Bird_Info.text = "選擇鳥類\n當前鳥類:北美紅雀";

            n = 1;
        }
        else if(n == 1){
            page[2].SetActive(true);
            page[1].SetActive(false);
            Sel_Bird_Info.text = "選擇鳥類\n當前鳥類:知更鳥";

            n = 2;
        }
        else if(n == 2){
            page[0].SetActive(true);
            page[2].SetActive(false);
            Sel_Bird_Info.text = "選擇鳥類\n當前鳥類:冠藍鴉";

            n = 0;
        }
    }

    public void Sure(){
        InputName.gameObject.SetActive(true);
        Sel_Bird_btn.SetActive(false);
        Sel_Bird_Info.gameObject.SetActive(false);
        Sel_Name_btn.SetActive(true);
    }

    public void Ido(){
        if(InputName.text.Length>0){
            PlayerPrefs.SetString("birdName",InputName.text);

            PlayerPrefs.SetInt("birdID",n);

            PlayerPrefs.SetInt("birdHungry",5);

            PlayerPrefs.SetInt("birdHp",5);

            PlayerPrefs.SetInt("Gold",10);

            PlayerPrefs.SetString("preTime","0");

            PlayerPrefs.Save();

            SceneManager.LoadScene("scence1");
        }
    }
    public void load(){
        SceneManager.LoadScene("scence1");
    }

}
