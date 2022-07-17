using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public Font font;
    private int UIMask = 1 << 5;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), new Vector3(0f, 0f, 1f), 100f, UIMask)) {
            reset();
        }
    }

    void OnGUI() {
        GUIStyle style = new GUIStyle();

        style.font = font;
        style.fontStyle = FontStyle.Bold;

        style.fontSize = 96;
        style.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect((Screen.width / 2) - 60, -120, 128, 1000), "Ran out of health!\nGame over!", style);
        GUI.Label(new Rect((Screen.width / 2) - 60, 60, 128, 1000), "Final score: " + GameData.score.ToString(), style);
        GUI.Label(new Rect((Screen.width / 2) - 60, 250, 128, 1000), "Click to Replay", style);
    }

    private void reset() {
        GameData.score = 0;
        GameData.space = 0;
        GameData.health = 3;
        GameData.traction = 5;
        GameData.enemySpeed = 3;
        GameData.message = "";

        SceneManager.LoadScene("Board", LoadSceneMode.Single);
    }

}
