using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f;
    Material myMaterial;
    Vector2 offSet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      myMaterial = GetComponent<Renderer>().material;

      offSet = new Vector2(0f, backgroundScrollSpeed);  
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
        Debug.Log(myMaterial.mainTextureOffset);
    }
}
