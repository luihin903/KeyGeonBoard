using UnityEngine;
using System;

public class Enemy : Character {
    
    public float speed;

    public Enemy() {
        int offset = (int) Math.Round(UnityEngine.Random.value*2 - 1);
        this.level = PlayerPrefs.GetInt("level") + offset;

        if (PlayerPrefs.GetInt("critical") == 1) {
            if (PlayerPrefs.GetInt("level") == 1) this.level = 1;
            else this.level = 6;
        }
        else {
            offset = (int) Math.Round(UnityEngine.Random.value * 3);
            if (offset == 3) offset = 0;
            this.level = PlayerPrefs.GetInt("dungeonLevel") * 3 - offset;
        }

        if (level <= 0) level = 1;
        this.maxHp = level * 10;
        this.hp = maxHp;
        this.atk = level * 2;
        this.def = level;
        this.speed = 1;

    }
}