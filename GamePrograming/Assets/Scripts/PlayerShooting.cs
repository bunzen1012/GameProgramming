using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;

    public void OnFire()
    {
            GameObject clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            OnFire(); 
        }
    }
}
