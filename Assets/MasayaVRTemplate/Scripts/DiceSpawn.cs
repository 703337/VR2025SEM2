using UnityEngine;

public class DiceSpawn : MonoBehaviour
{
    // Initial Variable Values
    [SerializeField] GameObject dice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //
    void OnTriggerEnter(Collider other)
    {
        Instantiate<GameObject>(dice, transform);
    }
}
