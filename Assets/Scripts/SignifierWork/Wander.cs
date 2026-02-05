using UnityEngine;

public class Wander : MonoBehaviour
{
    public Vector3 targ = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 movedir = targ - transform.position;
        transform.position += movedir.normalized * Time.deltaTime * speed;

        if(Vector3.Distance(transform.position, targ) < 0.5f)
        {
            targ = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
        }
    }
}
