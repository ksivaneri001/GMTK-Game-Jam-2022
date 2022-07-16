using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    private int spacesToGo;
    private DieBehavior dieScript;

    void Start() {
        dieScript = GameObject.Find("Die Container").GetComponent<DieBehavior>();

        StartCoroutine(moveRoutine());
    }

    void Update() {

    }

    private IEnumerator moveRoutine() {
        float waitTime = 0.5f;
        WaitForSeconds wait = new WaitForSeconds(waitTime);

        while (true) {
            yield return wait;

            if (spacesToGo > 0) {
                spacesToGo--;

                GameData.score++;
                GameData.space = (GameData.space == 27) ? 0 : GameData.space + 1;
                transform.parent = GameObject.Find("Board").transform.GetChild(GameData.space);
                transform.localPosition = new Vector3(0f, 0f, transform.localPosition.z);

                if (spacesToGo == 0) {
                    dieScript.resetDie();
                    checkSpace();
                }
            }
        }
    }

    private void checkSpace() {

    }

    public void setSpacesToGo(int s) {
        spacesToGo = s;
    }
}
