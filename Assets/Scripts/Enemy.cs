using UnityEngine;

public class Enemy : Character {
    
    public float speed;

    public Enemy() {

        this.level = (int) (Random.value * 9) + 1;
        this.maxHp = level * 10;
        this.hp = maxHp;
        this.atk = level * 2;
        this.def = level;
        this.speed = 1;
    }
}