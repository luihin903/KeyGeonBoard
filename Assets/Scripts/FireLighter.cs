using UnityEngine;

public class FireLighter : Character {

    public FireLighter(Character enemy) {
        this.atk = enemy.def + 5;
    }

}