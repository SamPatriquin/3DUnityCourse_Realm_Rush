using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour {
    [SerializeField][Range(0, 20)] float gridSnap = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSnap) * gridSnap;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSnap) * gridSnap;
        snapPos.y = 0f;

        transform.position = snapPos;
        textMesh.text = (snapPos.x/gridSnap + "," + snapPos.z/gridSnap);
    }
}
