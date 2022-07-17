using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLinear : MonoBehaviour {

    public float speed;
    public Vector2 startPoint;
    public Vector2 destination;

    void Start() {
        startPoint = transform.position;
        destination = transform.GetChild(0).transform.position;
        speed *= GameData.enemySpeed;
    }

    void Update() {
        if (Vector2.Distance(transform.position, destination) < (gameObject.GetComponent<Collider2D>().bounds.size.x * (speed / 10))) {
            transform.position = destination;
            Vector2 v = startPoint;
            startPoint = destination;
            destination = v;
        }
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    void OnDrawGizmos() {
        Debug.DrawRay(transform.GetChild(0).transform.position, new Vector2(0.2f, 0f), Color.red);
        Debug.DrawRay(transform.GetChild(0).transform.position, new Vector2(-0.2f, 0f), Color.red);
        Debug.DrawRay(transform.GetChild(0).transform.position, new Vector2(0f, 0.2f), Color.red);
        Debug.DrawRay(transform.GetChild(0).transform.position, new Vector2(0f, -0.2f), Color.red);
    }
}
