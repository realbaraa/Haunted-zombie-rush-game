using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    [SerializeField] private float bridgeSpeed=1;
     private float restPos = -33.77f;
     protected float startPos = 72.08f;

	
	protected virtual void Update ()
    {

        if (!GameManeger.instance.GameOver)
        {
              transform.Translate(Vector3.left * bridgeSpeed * Time.deltaTime);
            if (transform.localPosition.x <= restPos)
            {
                Vector3 rest = new Vector3(startPos, transform.position.y, transform.position.z);
                transform.position = rest;
            }
        }
	}

}
