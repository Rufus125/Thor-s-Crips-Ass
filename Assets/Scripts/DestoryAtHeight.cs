using UnityEngine;
using System.Collections;

public class DestoryAtHeight : MonoBehaviour {

    public float height;

    void Update() {

        if(transform.position.y < height)
            Destroy( gameObject ); 
    }
}
