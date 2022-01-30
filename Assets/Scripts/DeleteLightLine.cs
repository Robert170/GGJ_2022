using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteLightLine : MonoBehaviour
{

    RaycastHit2D lightLine;

    [SerializeField] GameObject player;

    [SerializeField] GameObject finalPoint;

    [SerializeField] GameObject lightBlock;

    private bool changePosition = false;

    public string levelName;


    private float distance;




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(lightBlock.transform.localScale);
        distance = (this.transform.position - finalPoint.transform.position).magnitude;

        lightLine = Physics2D.Raycast(this.transform.position, Vector2.down,
                                     distance);


        if (lightLine.collider.name == player.name)
        {
            Debug.DrawRay(this.transform.position, Vector2.down * distance, Color.green);
            Debug.Log(lightLine.collider.name);
            SceneManager.LoadScene(levelName);
        }
        if (lightLine.collider.name != player.name && !changePosition)
        {
            distance = (this.transform.position - finalPoint.transform.position).magnitude;

            // lightBlock.transform.position = new Vector3(lightBlock.transform.position.x, yPosition, lightBlock.transform.position.z);
            lightBlock.GetComponent<Renderer>().enabled = false;
            // Debug.Log(yPosition);
            changePosition = true;
        }


        if (lightLine.collider == null)
        {
            Debug.DrawRay(this.transform.position, Vector2.down * distance, Color.red);
        }
    }
}
