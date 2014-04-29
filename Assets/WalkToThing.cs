using UnityEngine;
using System.Collections;

public enum DirectionInt
{
    Down = 0, Left = 1, Up = 2, Right = 3
}

public class WalkToThing : MonoBehaviour {
    public float Speed = 1.5f;
    private Vector3 target;
    private float angle;
    private Animator anim;
    //private 
	// Use this for initialization
	void Start () {
        target = transform.position;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        var me = transform.position;
        angle = Mathf.Atan2(target.y - me.y, target.x - me.x) * 180 / Mathf.PI;
        if (angle < 0) angle += 360;
        
        //determine direction
        if (angle >= 30) anim.SetInteger("direction", (int)DirectionInt.Right);
        if (angle > 30)  anim.SetInteger("direction", (int)DirectionInt.Up);
        if (angle > 135) anim.SetInteger("direction", (int)DirectionInt.Left);
        if (angle > 210) anim.SetInteger("direction", (int)DirectionInt.Down);
        if (angle > 330) anim.SetInteger("direction", (int)DirectionInt.Right);


	}

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }


}
