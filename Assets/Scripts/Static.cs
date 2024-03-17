using UnityEngine;
using UnityEngine.UI;

public class Static {
    public static int TRUE = 1;
    public static int FALSE = 0;

    public static void setActive(GameObject target, bool value) {
        target.gameObject.SetActive(value);
    }

    public static void setActive(Image target, bool value) {
        target.gameObject.SetActive(value);
    }

    public static class pp {

        // Int
        public static int getInt(string key) {
            return PlayerPrefs.GetInt(key);
        }
        public static void setInt(string key, int value) {
            PlayerPrefs.SetInt(key, value);
        }

        // Bool
        public static bool getBool(string key) {
            return PlayerPrefs.GetInt(key) == TRUE;
        }
        public static void setBool(string key, bool value) {
            if (value) PlayerPrefs.SetInt(key, TRUE);
            else PlayerPrefs.SetInt(key, FALSE);
        }
    }
}