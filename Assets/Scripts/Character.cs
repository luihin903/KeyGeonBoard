using UnityEngine;
using System;
using static Static;

public abstract class Character {

    public int level;
    public int maxHp;
    public int hp;
    public int atk;
    public int def;

    public int attack(Character c) {
        int damage;
        if (this is Self && pp.getBool("Chest 1") == false) {
            damage = Math.Max(this.atk + 5 - c.def, 1);
        }
        else {
            damage = Math.Max(this.atk - c.def, 1);
        }
        c.hp -= damage;
        return damage;
    }

}