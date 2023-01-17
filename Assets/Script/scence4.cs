using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scence4 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int foodcount;

    [SerializeField] Text food_G;
    [SerializeField] int[] itemcount;
    [SerializeField] Text[] Icount;

    void Start()
    {
        foodcount = PlayerPrefs.GetInt("birdHungry",5);

        for (int i = 0; i < 3; i++)
        {
            itemcount[i] = PlayerPrefs.GetInt("item"+i,0);
            Icount[i].text = itemcount[i].ToString();
        }

        food_G.text = foodcount.ToString();
    }

    // Update is called once per frame

    public void eat(int x){
        if(itemcount[x-1]-1>=0){
            itemcount[x-1] -= 1;
            if(foodcount+x>5){
                foodcount = 5;
            }
            else{
                foodcount += x;
            }
            
            Icount[x-1].text = itemcount[x-1].ToString();
            food_G.text = foodcount.ToString();
        }
    }

    public void exit(){
        PlayerPrefs.SetInt("birdHungry",foodcount);

        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("item"+i,itemcount[i]);
        }

        PlayerPrefs.Save();

        SceneManager.LoadScene("scence1");
    }
}
