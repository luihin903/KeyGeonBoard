using UnityEngine;

public class Enemy {
    public int level;
    public int maxHp;
    public int hp;
    public int atk;
    public int def;

    public Enemy() {
        this.level = (int) (Random.value * 9) + 1;
        this.maxHp = level * 10;
        this.hp = maxHp;
        this.atk = level * 2;
        this.def = level;
    }
}