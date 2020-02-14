using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abduct : MonoBehaviour
{
    
    [SerializeField]
    private float Speed = 1;

    private Transform thisTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var shipPos = GameObject.Find("BAKE").transform.localPosition;

        if(shipPos.z <= -0.07 && shipPos.x >= 0.08f ){
            Vector3 move = new Vector3(0f, Speed * Time.deltaTime, 0f);
            thisTransform.localPosition += move;
            
        }
    }
}
