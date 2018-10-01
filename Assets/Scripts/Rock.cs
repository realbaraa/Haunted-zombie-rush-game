using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Bridge {

    [SerializeField] Vector3 topPos;
    [SerializeField] Vector3 bottomPos;

    public int speed = 5;
    //[SerializeField] private int rotationSpeed;

    void Start () {
        StartCoroutine(Move(bottomPos));
        startPos = 5f;
    }

    protected override void Update()
    {
        if (GameManeger.instance.PlayerActive)
        {
            base.Update();
        }
    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target-transform.position).y)>0.21)
        {
          //  transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * rotationSpeed);
            Vector3 dis = target == topPos ? Vector3.up : Vector3.down;
            transform.position += dis*Time.deltaTime*speed;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        Vector3 newTarget = topPos == target ? bottomPos : topPos;
        StartCoroutine(Move(newTarget));

    }


}
