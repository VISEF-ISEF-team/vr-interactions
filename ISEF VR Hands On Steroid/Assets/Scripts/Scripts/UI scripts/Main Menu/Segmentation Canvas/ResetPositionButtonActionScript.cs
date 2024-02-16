using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionButtonActionScript : MonoBehaviour
{
    public List<GameObject> childSegmentObjectList;
    public List<Vector3> oldPosition;
    public List<Quaternion> oldRotation; 

    private void Start()
    {
        oldPosition = new List<Vector3>();
        childSegmentObjectList = new List<GameObject>();
        oldRotation = new List<Quaternion>();
    }
    public void OnResetPositionButtonClick()
    {
        Debug.Log("reset button is called");
        Debug.Log(childSegmentObjectList.Count);
        Debug.Log(oldPosition.Count);
        Debug.Log(oldRotation.Count);

        if (childSegmentObjectList.Count > 11)
        {
            for (int i = 0; i < 11; i++)
            {
                childSegmentObjectList.RemoveAt(i); 
                oldPosition.RemoveAt(i);    
                oldRotation.RemoveAt(i);    
            }
        }

        for (int i = 0; i < childSegmentObjectList.Count; i++)
        {
            childSegmentObjectList[i].transform.rotation = oldRotation[i];  
            childSegmentObjectList[i].transform.position = oldPosition[i];
        }
    }
    
    public void ResetListContent()
    {
        childSegmentObjectList.Clear();
        oldPosition.Clear();
        oldRotation.Clear(); 
    }
}
