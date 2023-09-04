using UnityEngine;

public class LODExample : MonoBehaviour
{
    public GameObject highDetailObject;
    public GameObject mediumDetailObject;
    public GameObject lowDetailObject;

    private LODGroup lodGroup;
    private LOD[] lods;

    void Start()
    {
        
        lodGroup = GetComponent<LODGroup>();

        
        lods = new LOD[3];
        lods[0] = new LOD(1.0f, new Renderer[] { highDetailObject.GetComponent<Renderer>() });
        lods[1] = new LOD(0.5f, new Renderer[] { mediumDetailObject.GetComponent<Renderer>() });
        lods[2] = new LOD(0.0f, new Renderer[] { lowDetailObject.GetComponent<Renderer>() });

        
        lodGroup.SetLODs(lods);
    }

    void Update()
    {
       
        float distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);

        if (distanceToCamera > 10f)
        {
           
            lodGroup.ForceLOD(2); 
        }
        else if (distanceToCamera > 5f) 
        {
            lodGroup.ForceLOD(1);
        }
        else
        {
            lodGroup.ForceLOD(0);
        }
    }
}
