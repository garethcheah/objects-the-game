using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStructures : MonoBehaviour
{
    private Rigidbody2D[] rigidBodies;
    private List<Rigidbody2D> rigidBodiesList;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb1 = new Rigidbody2D();
        Rigidbody2D rb2 = new Rigidbody2D();
        Rigidbody2D rb3 = new Rigidbody2D();
        Rigidbody2D rb4 = new Rigidbody2D();

        // Initialize array
        rigidBodies = new Rigidbody2D[] { rb1, rb2, rb3, rb4 };

        // Initialize list
        rigidBodiesList.Add(rb1);
        rigidBodiesList.Add(rb2);
        rigidBodiesList.Add (rb3);
        rigidBodiesList.Add((rb4));
    }

    public Rigidbody2D GetRandomRigidBodyFromArray()
    {
        return rigidBodies[Random.Range(0, rigidBodies.Length)];
    }

    public Rigidbody2D GetRandomRigidBodyFromList()
    {
        return rigidBodiesList[Random.Range(0, rigidBodiesList.Count)];
    }

    public void DestroyRigidBodyFromList(int index)
    {
        if (index < rigidBodiesList.Count)
        {
            Destroy(rigidBodiesList[index]);
            rigidBodiesList.RemoveAt(index);
        }
    }
}
