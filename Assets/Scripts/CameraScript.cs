using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject Jhon;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Jhon.transform.position.x;
        transform.position = position;

    }
}
