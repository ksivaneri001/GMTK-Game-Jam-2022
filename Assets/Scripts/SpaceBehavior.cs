using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceBehavior : MonoBehaviour {

    public enum SpaceType {
        Health,
        Traction,
        Speed,
        Level,
        Blank
    }

    private string[] scenePaths = { "GameOver", "Lv 1", "Lv 2", "Lv 3", "Lv 4" };

    public SpaceType type;
    public int modifier;

    public void checkSpace() {
        if (type == SpaceType.Health) {
            GameData.health += modifier;

            GameData.message = (modifier > 0)
            ? "Player gained " + modifier.ToString() + "\nhealth."
            : "Player lost " + (-1 * modifier).ToString() + "\nhealth.";
        }
        else if (type == SpaceType.Traction) {
            GameData.traction += modifier;

            GameData.message = (modifier > 0)
            ? "Player traction\nincreased\nby " + modifier.ToString() + "."
            : "Player traction\ndecreased\nby " + (-1 * modifier).ToString() + ".";
        }
        else if (type == SpaceType.Speed) {
            GameData.enemySpeed += modifier;

            GameData.message = (modifier > 0)
            ? "Enemy speed\nincreased\nby " + modifier.ToString() + "."
            : "Enemy speed\ndecreased\nby " + (-1 * modifier).ToString() + ".";
        }
        else if (type == SpaceType.Level) {
            SceneManager.LoadScene(scenePaths[modifier], LoadSceneMode.Single);

            GameData.message = "Played level " + modifier.ToString() + ".";
        }
        else if (type == SpaceType.Blank) {
            GameData.message = "Landed on \nblank space.";
        }
    }
}
