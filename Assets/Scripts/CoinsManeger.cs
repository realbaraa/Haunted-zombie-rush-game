using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManeger : MonoBehaviour {


    void Update() {
        transform.position += Vector3.left * Time.deltaTime;
        if (transform.position.x < -9)
            Destroy(gameObject);
    }


}
