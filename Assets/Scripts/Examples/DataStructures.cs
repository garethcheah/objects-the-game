using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//using Unity.VisualScripting;
using UnityEngine;

public class DataStructures : MonoBehaviour
{
    private Rigidbody2D[] rigidBodies;
    private List<Rigidbody2D> rigidBodiesList;
    private LinkedList<Rigidbody2D> rbLinkedList = new LinkedList<Rigidbody2D>();
    private Hashtable rbHashtable = new Hashtable();
    private Dictionary<int, Rigidbody2D> rbDictionary = new Dictionary<int, Rigidbody2D>();

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

        rbLinkedList.AddLast(rb1);
        rbLinkedList.AddLast(rb2);
        rbLinkedList.AddLast(rb3);
        rbLinkedList.AddLast(rb4);

        rbHashtable.Add(1, rb1);
        rbHashtable.Add(2, rb2);
        rbHashtable.Add(3, rb3);
        rbHashtable.Add(4, rb4);

        rbDictionary.Add(1, rb1);
        rbDictionary.Add(2, rb2);
        rbDictionary.Add(3, rb3);
        rbDictionary.Add(4, rb4);
    }

    public Rigidbody2D GetRandomRigidBodyFromArray()
    {
        return rigidBodies[Random.Range(0, rigidBodies.Length)];
    }

    public Rigidbody2D GetRandomRigidBodyFromList()
    {
        return rigidBodiesList[Random.Range(0, rigidBodiesList.Count)];
    }

    public Rigidbody2D GetRandomRigidBodyFromLinkedList()
    {
        int randomIndex = Random.Range(0, rbLinkedList.Count);
        LinkedListNode<Rigidbody2D> node = rbLinkedList.First;

        for (int i = 0; i < randomIndex; i++)
        {
            node = node.Next;
        }

        return node.Value;
    }

    public Rigidbody2D GetRandomRigidBodyFromHashtable()
    {
        int randomIndex = Random.Range(0, rbHashtable.Count);
        Rigidbody2D rbReturn = null;

        if (rbHashtable.ContainsKey(randomIndex))
        {
            rbReturn = rbHashtable[randomIndex].ConvertTo<Rigidbody2D>();
        }

        return rbReturn;
    }

    public Rigidbody2D GetRandomRigidBodyFromDictionary()
    {
        int randomIndex = Random.Range(0, rbDictionary.Count);
        Rigidbody2D rbReturn;

        if (!rbDictionary.TryGetValue(randomIndex, out rbReturn))
        {
            rbReturn = null;
        }

        return rbReturn;
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
