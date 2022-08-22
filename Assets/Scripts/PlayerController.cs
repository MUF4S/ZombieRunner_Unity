using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool right;
    public int points =1;
    [SerializeField] List<GameObject> manekins;
    [SerializeField]List<GameObject> showedManekins;
    [SerializeField]List<GameObject>hidenManekins;
    [SerializeField]List<GameObject> biggerManekins;
    public GameObject biggerZombie;
    public TextMeshProUGUI text;
    Animator[] anim;
    bool mid = false;
    GameObject objToDestroy;
    

    public GameObject manekin;
    public  Vector2 manekinMove;
    int howManyToDestroy;
    int howManyToAdd;
    float startTime = 0.5f;
    public float moveSpeed;
    int bigManekin;
    int allManekins;
    
    Vector3 zPos = new Vector3(0,0,5);

    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 1; i < transform.childCount; i++)
        {
            manekins.Add(transform.GetChild(i).gameObject);
        }
        allManekins =manekins.Count;
    }
   
    

    // Update is called once per frame
    void Update()
    {

        text.text = points.ToString();
        if(right)
        {
            transform.position = new Vector3(transform.position.x,0f,zPos.z);
        }
        else{
            transform.position = new Vector3(transform.position.x,0f,-zPos.z);
        }
        Move();
        if(startTime>=0)
        {
            startTime -= Time.deltaTime;
        }

            if(howManyToDestroy>0)
            {
               
                if(biggerManekins.Count>0)
                {
                     if(biggerManekins[biggerManekins.Count-1].transform.localScale.x <= 1f){
                        showedManekins.Add(biggerManekins[biggerManekins.Count-1]);
                        biggerManekins.RemoveAt(biggerManekins.Count-1);

                    }

                    if(biggerManekins[biggerManekins.Count-1].transform.localScale.x >=2f){
                        Destroy(biggerManekins[biggerManekins.Count-1]);
                        biggerManekins.RemoveAt(biggerManekins.Count-1);
                        hidenManekins[hidenManekins.Count-1].layer =0;
                        for (int j = 0; j < hidenManekins[hidenManekins.Count-1].transform.childCount-1; j++)
                            {
                                hidenManekins[hidenManekins.Count-1].transform.GetChild(j).gameObject.layer =0;
                            }
                        biggerManekins.Add( hidenManekins[hidenManekins.Count-1]);
                        hidenManekins.RemoveAt(hidenManekins.Count-1);
                        bigManekin--;
                    }
                   
                  //  biggerManekins.Add(hidenManekins[hidenManekins.Count-1]);
                   
                    if(biggerManekins[biggerManekins.Count-1].transform.localScale.x >1f){
                        biggerManekins[biggerManekins.Count-1].transform.localScale -= new Vector3(0.1f,0.1f,0.1f);
                        howManyToDestroy--;
                    }

                    
                   
                }

                if(biggerManekins.Count==0)
                {

                    
                    
                    howManyToDestroy--;
                    
                    showedManekins[showedManekins.Count-1].layer =6;
                    for (int j = 0; j < showedManekins[showedManekins.Count-1].transform.childCount-1; j++)
                        {
                            showedManekins[showedManekins.Count-1].transform.GetChild(j).gameObject.layer =6;
                        }
                        manekins.Add(showedManekins[showedManekins.Count-1]);
                        showedManekins.RemoveAt(showedManekins.Count-1);
                    
                }

                
                
            }
        
        
            if(howManyToAdd>0)
            {
                
                if(manekins.Count>0)
                {
                    manekins[0].layer =0;
                    for (int j = 0; j < manekins[0].transform.childCount; j++)
                        {
                            manekins[0].transform.GetChild(j).gameObject.layer =0;
                        }

                    showedManekins.Add(manekins[0]);
                    manekins.RemoveAt(0);
                    howManyToAdd--;
                }
                if(manekins.Count==0)
                {
                   if(biggerManekins.Count==0){
                            biggerManekins.Add(showedManekins[0]);
                            showedManekins.RemoveAt(0);
                        }
                    if(biggerManekins.Count>0){
                        
                        if(biggerManekins[bigManekin].transform.localScale.x <2f && howManyToAdd>0)
                        {
                            biggerManekins[bigManekin].transform.localScale += new Vector3(0.1f,0.1f,0.1f);
                            howManyToAdd--;
                        }

                        if(biggerManekins[bigManekin].transform.localScale.x >= 2f)
                        {
                            
                            hidenManekins.Add(biggerManekins[bigManekin]);
                            hidenManekins[hidenManekins.Count-1].layer =6;
                            hidenManekins[hidenManekins.Count-1].transform.localScale -= new Vector3(0.1f,0.1f,0.1f);
                            for (int j = 0; j < hidenManekins[hidenManekins.Count-1].transform.childCount-1; j++)
                        {
                            hidenManekins[hidenManekins.Count-1].transform.GetChild(j).gameObject.layer =6;
                        }
                            biggerManekins[bigManekin] = Instantiate(biggerZombie,biggerManekins[bigManekin].transform.position, biggerManekins[bigManekin].transform.rotation,this.transform);
                            biggerManekins[bigManekin].transform.localScale *=2f;
                            bigManekin++;
                            biggerManekins.Add(showedManekins[0]);
                            showedManekins.RemoveAt(0);
                        }
                    }
                    
                    

                
                }

                
                
            }
        
        if(manekins.Count == allManekins){
           // points = 1;
        }
        if(mid)
        {
            zPos = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y,0f),2f);
        }

        if(points <=0){
            Time.timeScale = 0f;
            Destroy(objToDestroy);
            
        }
        
    }

    void Move(){
       
       // transform.position -= transform.right * Time.fixedDeltaTime * moveSpeed;
        transform.Translate(new Vector3(-1f,0f,0f)*Time.deltaTime*moveSpeed);
       
        
    }
    

    public void DevidePlayers(int howMany,GameObject obj){
        if(showedManekins.Count>0 || biggerManekins.Count>0)
        {
            int all = Mathf.FloorToInt(points/howMany);
            int disparity = points - all;
            howManyToDestroy += disparity;
            points -= disparity;
            objToDestroy = obj;
        }
       
        
    }
    public void AddPlayers(int howMany,GameObject obj)
    {
            objToDestroy = obj;
            howManyToAdd += howMany;
            points += howMany;
    }
    public void RemovePlayers(int howMany,GameObject obj)
    {
            objToDestroy = obj;
            howManyToDestroy += howMany;
            points -= howMany;
    }
    public void MultiplyPlayers(int howMany,GameObject obj){
        int all = points*howMany;
        int disparity = all - points;
        howManyToAdd += disparity;
        points += disparity;
        objToDestroy = obj;
    }

    public void FinalAction(){
         anim = GetComponentsInChildren<Animator>();
        
        moveSpeed =3f;
       for (int i = 0; i < anim.Length; i++)
       {
         anim[i].speed = 0.6f;
       }
        mid=true;
    }
}
