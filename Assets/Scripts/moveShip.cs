    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1;

    private Transform thisTransform;
    
    bool move1 = false;
    bool move2 = false;
    bool move3 = false;
    bool turn1 = false;
    bool turn2 = false;
    public static bool imgFound = false;

    float xRot;
    float zRot;

    Vector3 imgV;

    public GameObject img;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        img = GameObject.FindGameObjectWithTag("image");
        xRot = img.transform.rotation.x*100;
        zRot = img.transform.rotation.z*100;

        
         
        
        if(Time.time > 5  
            && xRot < 20 
            && xRot > -20
            && zRot < 20
            && zRot > -20){

            print("x= " + xRot );
            print("z= " + zRot );

            if(!move1){
                
                if(thisTransform.localPosition.z < 1.0823){
                    Vector3 move = new Vector3(0f, 0f, Speed * Time.deltaTime);
                    thisTransform.localPosition += move;
                }else{
                    move1 = true;
                }
            }

            if(move1 && !turn1){
                if(thisTransform.localRotation.y <= 0.7){
                    thisTransform.Rotate(0, 70 * Time.deltaTime,0, Space.Self);
                } else {
                    turn1 = true;
                }
            }

            if(turn1 && !move2){
                if(thisTransform.localPosition.x < 0.80f){
                    Vector3 move = new Vector3(Speed * Time.deltaTime,0f, 0f);
                    thisTransform.localPosition += move;
                }else{
                    move2 = true;
                }
            }

            if(move2 && !turn2){
                if(thisTransform.localRotation.y < 0.999){
                    thisTransform.Rotate(0, 70 * Time.deltaTime, 0, Space.Self);
                } else {
                    turn2 = true;
                }
            }

            if(turn2 && !move3){
                if(thisTransform.localPosition.z > -0.07){
                    Vector3 move = new Vector3(0f, 0f, Speed * Time.deltaTime);
                    thisTransform.localPosition -= move;
                }else{
                    move3 = true;
                }
            }

            if(move3){
                if(GameObject.Find("CowBIW") == null){
                    if(thisTransform.localPosition.z > -2.15f){
                        Vector3 move = new Vector3(0f, 0f, Speed * Time.deltaTime);
                        thisTransform.localPosition -= move;
                    }
                }
            }
        }
    }


    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Cow")){
            other.gameObject.SetActive(false);
        }
    }
}
