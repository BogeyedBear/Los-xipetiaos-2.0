using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    private Mesh mesh;
    public float fov = 360f;
    public int numAristas = 360;
    public float anguloInicial = 0;
    public float distanciaVision = 8f;
    private Vector3 origen;
    public LayerMask layerMask;
    private Camera currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = Camera.main;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origen = Vector3.zero;
        //GameObject gameobject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
    }

    private void GenerarMesh()
    {
        Vector3[] vertices = new Vector3[numAristas + 2];
        int[] triangulos = new int[numAristas * 3];
        float anguloActual = anguloInicial;
        float incrementoAngulo = fov / numAristas;
        vertices[0] = transform.localPosition;
        int indeceVertices = 1;
        int indeceTriangulos = 0;
        for(int i = 0; i <= numAristas; i++)
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origen, GetVectorFromAngle(anguloActual), distanciaVision, layerMask);
            Vector3 verticeActual;
            if (raycastHit2D.collider == null)
            {
                // No hit
                verticeActual = transform.localPosition + GetVectorFromAngle(anguloActual) * distanciaVision;
            }
            else
            {
                // Hit object
                verticeActual = currentCamera.transform.InverseTransformPoint(raycastHit2D.point);
            }
            vertices[indeceVertices] = verticeActual;
            if(i != 0)
            {
                triangulos[indeceTriangulos] = 0;
                triangulos[indeceTriangulos + 1] = indeceVertices - 1;
                triangulos[indeceTriangulos + 2] = indeceVertices;
                indeceTriangulos += 3;
            }
            indeceVertices++;
            anguloActual -= incrementoAngulo;
            mesh.vertices = vertices;
            mesh.triangles = triangulos;
        }
        /**vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(1,0,0),
            new Vector3(0,-1,0)
        };

        triangulos = new int[]
        {
            0,1,2
        };

        mesh.vertices = vertices;
        mesh.triangles = triangulos;
        **/
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public void SetOrigin(Vector3 newOrigin)
    {
        origen = newOrigin;

    }

    // Update is called once per frame
    void Update()
    {
        GenerarMesh();
    }
}
