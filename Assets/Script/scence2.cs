using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scence2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int Goldcount;

    [SerializeField] Text Gold_G;
    [SerializeField] int[] itemcount;
    [SerializeField] Text[] Icount;

    void Start()
    {
        Goldcount = PlayerPrefs.GetInt("Gold",10);

        for (int i = 0; i < 3; i++)
        {
            itemcount[i] = PlayerPrefs.GetInt("item"+i,0);
            Icount[i].text = itemcount[i].ToString();
        }

        Gold_G.text = Goldcount.ToString();
    }

    // Update is called once per frame

    public void buy(int x){
        if(Goldcount>=x){
            Goldcount -= x;
            itemcount[x/5-2]++;
            Icount[x/5-2].text = itemcount[x/5-2].ToString();
            Gold_G.text = Goldcount.ToString();
        }
    }

    public void exit(){
        PlayerPrefs.SetInt("Gold",Goldcount);

        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("item"+i,itemcount[i]);
        }

        PlayerPrefs.Save();

        SceneManager.LoadScene("scence1");
    }
}
