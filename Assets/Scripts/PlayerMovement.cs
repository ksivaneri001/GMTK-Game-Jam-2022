using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float maxSpeed;
    public float maxInvincibilityTime;
    private float invincibilityTime;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Font font;
    public Texture2D texture;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb.drag = GameData.traction;
        speed += 50 * GameData.traction;
        invincibilityTime = 0f;
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(speed * transform.up * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(-1 * speed * transform.up * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(-1 * speed * transform.right * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.AddForce(speed * transform.right * Time.deltaTime);
        }
    }

    void Update() {
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if (invincibilityTime > 0f) {
            invincibilityTime -= Time.deltaTime;
            sr.color = Color.red;
        }
        else {
            sr.color = Color.white;
        }
    }

    void OnGUI() {
        GUIStyle style = new GUIStyle();

        style.font = font;
        style.fontSize = 72;
        style.fontStyle = FontStyle.Bold;

        GUI.Label(new Rect(20, 80, 128, 128), texture);
        GUI.Label(new Rect(110, 60, 128, 128), "x " + GameData.health.ToString(), style);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Win Zone") {
            SceneManager.LoadScene("Board", LoadSceneMode.Single);
        }
        if (col.gameObject.tag == "Enemy" && invincibilityTime <= 0f) {
            GameData.health -= 1;
            invincibilityTime = maxInvincibilityTime;
        }
    }
}
