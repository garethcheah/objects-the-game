using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create Player
        Player player = new Player();

        // Create enemies
        Enemy enemy1 = new Enemy("enemy1", EnemyType.MachineGun);
        Enemy enemy2 = new Enemy("enemy2", EnemyType.Shooter);

        // Create weapons
        Weapon gun = new Weapon();
        Weapon assaultRifle = new Weapon("Assault Rifle", 50.0f);
        Weapon machineGun = new Weapon();

        // Assign weapons
        player.weapon = gun;
        enemy1.weapon = machineGun;
        enemy2.weapon = assaultRifle;
    }
}
