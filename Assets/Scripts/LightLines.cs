using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightLines : MonoBehaviour
{

    RaycastHit2D lightLine;

    [SerializeField] GameObject player;

    [SerializeField] GameObject finalPoint;

    public string levelName;


    private float distance;




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distance = (this.transform.position - finalPoint.transform.position).magnitude;

        lightLine = Physics2D.Raycast(this.transform.position, Vector2.down,
                                     distance);


        if (lightLine.collider.name == player.name)
        {
            Debug.DrawRay(this.transform.position, Vector2.down * distance, Color.green);
            Debug.Log(lightLine.collider.name);
            SceneManager.LoadScene(levelName);
        }
        if (lightLine.collider.name != player.name)
        {
            distance = (this.transform.position - finalPoint.transform.position).magnitude;
        }


        if (lightLine.collider == null)
        {
            Debug.DrawRay(this.transform.position, Vector2.down * distance, Color.red);
        }
    }
}
