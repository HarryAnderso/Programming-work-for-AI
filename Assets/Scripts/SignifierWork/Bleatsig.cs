using UnityEngine;

public class Bleatsig : MonoBehaviour
{

    public AudioSource audiosource;

    public AudioClip bleat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Bleat script started");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            audiosource.PlayOneShot(bleat, 1);
            Debug.Log("Bleat sound played");
        }
    }
}
