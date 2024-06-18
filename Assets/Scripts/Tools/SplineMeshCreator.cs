using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

namespace Tools
{
    public class SplineMeshCreator : MonoBehaviour
    {
        [Header("Spline Mesh Settings")]
        [SerializeField] private SplineContainer splineContainer;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private MeshCollider meshCollider;
        [SerializeField] private float width;
        [SerializeField] private int resolution;
        [SerializeField] private bool autoUpdate;
    
        [Space] [Header("Edge Objects")]
        [SerializeField] private Transform edgePrefabContainer;
        [SerializeField] private GameObject edgePrefab;
        [SerializeField] private float distanceFromEdge = 1.0f;

        public bool AutoUpdate => autoUpdate;

        private int _splineIndex;
        private float3 _forward;
        private float3 _position;
        private float3 _upVector;

        private List<Vector3> _verticesP1;
        private List<Vector3> _verticesP2;

        /// <summary>
        /// Invoked once the component is loaded or a value has been changed in the inspector
        /// </summary>
        public event Action OnValueChanged;

        private void Start()
        {
            BuildMesh();
        }

        private void CalculateSplineWidth(float time, out Vector3 p1, out Vector3 p2)
        {
            splineContainer.Evaluate(_splineIndex, time, out _position, out _forward, out _upVector);

            float3 right = Vector3.Cross(_forward, _upVector).normalized;
            p1 = _position + right * width;
            p2 = _position + -right * width;
        }

        private void GetVertices()
        {
            _verticesP1 = new List<Vector3>();
            _verticesP2 = new List<Vector3>();

            var step = 1f / resolution;
            for (var i = 0; i < resolution; i++)
            {
                var time = step * i;
                CalculateSplineWidth(time, out var p1, out var p2);
                _verticesP1.Add(p1);
                _verticesP2.Add(p2);
            }
        }

        public void BuildMesh()
        {
            GetVertices();

            var mesh = new Mesh();

            var vertices = new List<Vector3>();
            var tris = new List<int>();

            var length = _verticesP2.Count;

            var isClosed = splineContainer.Spline.Closed;
        
            for (var i = 0; i < length - (isClosed ? 0 : 1); i++)
            {
                var p1 = _verticesP1[i];
                var p2 = _verticesP2[i];

                if (!isClosed && i == length - 1)
                {
                    break;
                }

                var p3 = _verticesP1[(i + 1) % length];
                var p4 = _verticesP2[(i + 1) % length];

                var offset = 4 * i;

                var t1 = offset + 0;
                var t2 = offset + 2;
                var t3 = offset + 3;

                var t4 = offset + 3;
                var t5 = offset + 1;
                var t6 = offset + 0;

                vertices.AddRange(new List<Vector3> { p1, p2, p3, p4 });
                tris.AddRange(new List<int> { t1, t2, t3, t4, t5, t6 });
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = tris.ToArray();

            meshFilter.sharedMesh = mesh;
            meshCollider.sharedMesh = mesh;
        }
    
        public void SpawnEdgePrefabs()
        {
            if (edgePrefab == null || edgePrefabContainer == null)
            {
                Debug.LogError("Edge prefab or container is not set.");
                return;
            }
        
            for (var i = edgePrefabContainer.childCount; i > 0; --i)
                DestroyImmediate(edgePrefabContainer.GetChild(0).gameObject);
        
            var innerEdgePositions = new List<Vector3>();
            var outerEdgePositions = new List<Vector3>();
            for (var i = 0; i < _verticesP1.Count; i++)
            {
                var time = (1f / resolution) * i;
                CalculateSplineWidth(time, out var p1, out var p2);

                var direction1 = p1 - (Vector3)splineContainer.EvaluatePosition(time - 0.01f);
                var direction2 = p2 - (Vector3)splineContainer.EvaluatePosition(time - 0.01f);
            
                var objectSize = edgePrefab.GetComponent<Renderer>().bounds.size.x;
            
                var edgePosition1 = p1 - direction1.normalized * (objectSize * 0.5f);
                var edgePosition2 = p2 - direction2.normalized * (objectSize * 0.5f);
            
                edgePosition1.y += edgePrefab.GetComponent<Renderer>().bounds.extents.y;
                edgePosition2.y += edgePrefab.GetComponent<Renderer>().bounds.extents.y;
            
                innerEdgePositions.Add(edgePosition1);
                outerEdgePositions.Add(edgePosition2);
            
                var nextIndex = (i + 1) % _verticesP1.Count;
                var nextDirection1 = _verticesP1[nextIndex] - p1;
                var nextDirection2 = _verticesP2[nextIndex] - p2;

                var rotation1 = Quaternion.LookRotation(nextDirection1, _upVector);
                var rotation2 = Quaternion.LookRotation(nextDirection2, _upVector);
            
                edgePosition1 += direction1.normalized * distanceFromEdge;
                edgePosition2 += direction2.normalized * distanceFromEdge;
            
                var edgePrefab1 = Instantiate(edgePrefab, edgePosition1, rotation1, edgePrefabContainer);
                var edgePrefab2 = Instantiate(edgePrefab, edgePosition2, rotation2, edgePrefabContainer);
            }

            // TODO: Uh more stuff??
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            EditorApplication.delayCall += _OnValidate;
        }

        private void _OnValidate()
        {
            OnValueChanged?.Invoke();
        }
#endif
    }
}
