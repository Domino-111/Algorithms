using System.Collections.Generic;
using UnityEngine;

namespace MyPathfinding
{
    public class Node : MonoBehaviour
    {
        public List<Node> Neighbours;

        float pathWeight;
        public float PathWeight
        {
            get
            {
                return pathWeight;
            }
            set
            {
                pathWeight = value;
            }
        }

        private Node previousNode;
        public Node PreviousNode
        {
            get => previousNode; set => previousNode = value;
        }

        public void Reset()
        {
            pathWeight = float.PositiveInfinity;
            previousNode = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawSphere(transform.position, 0.2f);
        }
    }
}

