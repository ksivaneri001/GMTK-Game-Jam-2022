using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public Font font;
    public Texture2D texture;

    private int spacesToGo;
    private DieBehavior dieScript;

    void Start() {
        dieScript = GameObject.Find("Die Container").GetComponent<DieBehavior>();

        StartCoroutine(moveRoutine());
    }

    void OnGUI() {
        GUIStyle style = new GUIStyle();

        style.font = font;
        style.fontSize = 72;
        style.fontStyle = FontStyle.Bold;

        GUI.Label(new Rect(20, 80, 128, 128), texture);
        GUI.Label(new Rect(110, 60, 128, 128), "x " + GameData.health.ToString(), style);

        GUI.Label(new Rect(20, 240, 128, 128), "Traction: " + GameData.traction.ToString(), style);

        style.fontSize = 56;
        GUI.Label(new Rect(20, 420, 128, 128), "Enemy Speed: " + GameData.enemySpeed.ToString(), style);

        GUI.Label(new Rect(Screen.width - 400, 80, 128, 1000), GameData.message, style);
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
                    transform.parent.gameObject.GetComponent<SpaceBehavior>().checkSpace();
                }
            }
        }
    }

    public void setSpacesToGo(int s) {
        spacesToGo = s;
    }
}
