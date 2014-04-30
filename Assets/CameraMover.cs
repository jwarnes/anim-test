using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

    public Transform Follow;
    public float Speed = 5;
    public float MaxDistance = 3f;
    private Vector3 target;
    private Vector3 mousePos;
    private Transform ball;
	void Start () {
        if (Follow == null)
            Follow = GameObject.Find("player").transform;

        ball = GameObject.Find("ball").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var followPos = Follow.transform.position;
        target = transform.position;
        if(mousePos.x > target.x) 
            target.x = (followPos.x + Mathf.Min(mousePos.x - followPos.x, MaxDistance) / 2);
        else
            target.x = (followPos.x + Mathf.Max(mousePos.x - followPos.x, -MaxDistance) / 2);
	}
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        //var time = Mathfx.Hermite(0.0, 1.0, Time.time);
        //transform.position = Vector3.Lerp(transform.position, target, time);
        
    }
}
