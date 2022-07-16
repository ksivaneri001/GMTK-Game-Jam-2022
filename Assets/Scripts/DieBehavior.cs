using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBehavior : MonoBehaviour {

    private int rollValue;
    private Animator anim;
    private SpriteRenderer[] srArray;
    private PlayerBehavior playerScript;

    private int dieMask = 1 << 6;

    void Start() {
        anim = gameObject.GetComponent<Animator>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerBehavior>();

        srArray = new SpriteRenderer[7];
        for (int i = 0; i < 7; i++) {
            srArray[i] = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
        }
    }

    void Update() {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {

            if (Physics.Raycast(GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), new Vector3(0f, 0f, 1f), 100f, dieMask)) {
                transform.localScale = new Vector3(1.6f, 1.6f, 1f);

                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    anim.SetTrigger("doRoll");
                }
            }
            else {
                transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            }
        }
        else {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
        
        Debug.DrawRay(GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), new Vector3(0f, 0f, 100f), Color.red);
    }

    public void dieAnimEvent() {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        rollValue = Random.Range(1, 7);

        srArray[0].enabled = false;
        srArray[rollValue].enabled = true;
        playerScript.setSpacesToGo(rollValue);
    }

    public void resetDie() {
        srArray[0].enabled = true;
        for (int i = 1; i < 7; i++) {
            srArray[i].enabled = false;
        }
        anim.Play("Idle");
    }
}
