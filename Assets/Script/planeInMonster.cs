using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeInMonster : MonoBehaviour
{
    // Start is called before the first frame update

    

    

    //public static int monsterCount;

    // Start is called before the first frame update
    

    // Update is called once per frame
    
    void update()
    {
        
        /*
        bool doInput = false;

        if(Input.touchCount > 0){
            if(touchCount == 0){
                touchCount = Input.touchCount;
                doInput = true;
            }
        }  
        else
        {
            touchCount = 0;
        } 


        if(doInput){
            Vector2 touchPos = new Vector2(Input.GetTouch(0).position.x,Input.GetTouch(0).position.y);
            Ray ray = Camera.main.ScreenPointToRay(touchPos);

            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray,out hit,1000)){
                if(hit.normal.y<0.95f)return;
                // FindObjectOfType<scence3>().scoreManage(3);
                GameObject obj = Instantiate(TheObj,hit.point,Quaternion.identity);
                Destroy(obj,10);
            }
        }
        */
    }
}
