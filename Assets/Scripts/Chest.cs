using UnityEngine;
using static Static;

public class Chest : MonoBehaviour {
    
    void Start() {
        setActive(gameObject, pp.getBool(gameObject.name));
    }

}