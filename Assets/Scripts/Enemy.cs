using UnityEngine;
using System;

public class Enemy : Character {
    
    public float speed;

    public Enemy() {
        int offset = (int) Math.Round(UnityEngine.Random.value*2 - 1);
        this.level = PlayerPrefs.GetInt("level") + offset;
        if (level <= 0) level = 1;
        this.maxHp = level * 10;
        this.hp = maxHp;
        this.atk = level * 2;
        this.def = level;
        this.speed = 1;

    }
}