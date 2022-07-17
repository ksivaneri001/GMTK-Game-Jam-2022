using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadial : MonoBehaviour {

    public float degreesPerSecond;
    public Vector2 center;
    public float radius;
    public int direction;

    void Start() {
        center = transform.parent.transform.position;
        radius = Vector2.Distance(transform.position, transform.parent.transform.position);
        degreesPerSecond *= (0.75f * GameData.enemySpeed);
    }

    void Update() {
        float theta = Mathf.Atan2(transform.localPosition.y, transform.localPosition.x);
        theta += (Mathf.PI / 180) * degreesPerSecond * Time.deltaTime * direction;
        transform.localPosition = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), transform.localPosition.z);
    }

    void OnDrawGizmos() {
        Debug.DrawRay(transform.parent.transform.position, new Vector2(0.2f, 0f), Color.blue);
        Debug.DrawRay(transform.parent.transform.position, new Vector2(-0.2f, 0f), Color.blue);
        Debug.DrawRay(transform.parent.transform.position, new Vector2(0f, 0.2f), Color.blue);
        Debug.DrawRay(transform.parent.transform.position, new Vector2(0f, -0.2f), Color.blue);
    }
}
