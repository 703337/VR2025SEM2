using Unity.XR.CoreUtils;
using UnityEngine;

public class DiceSpawn : MonoBehaviour
{
    // Initial Variable Values
    [SerializeField] GameObject dice;
    [SerializeField] Transform spawn;

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
        if (other.gameObject.tag == "GameController")
        {
            Debug.Log("Spawn");
            GameObject obj = Instantiate(dice, spawn.position, spawn.rotation);
        }
    }
}
