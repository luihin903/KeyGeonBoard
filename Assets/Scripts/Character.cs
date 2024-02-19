using UnityEngine;
using System;

public abstract class Character {

    public int level;
    public int maxHp;
    public int hp;
    public int atk;
    public int def;

    public void attack(Character c) {
        int damage = Math.Max(this.atk - c.def, 1);
        c.hp -= damage;
    }

}