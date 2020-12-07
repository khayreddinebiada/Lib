using UnityEngine;

namespace game.lib
{
    [ExecuteInEditMode]
    public class GizmasBetweenPoints : MonoBehaviour
    {
        [Header("Between points")]
        [SerializeField]
        private bool _isGizmosBetweenPoints = true;
        [SerializeField]
        private Color _GizmosColorBetweenPoints = Color.red;
        [SerializeField]
        private bool isLooping = false;

        [Header("On point")]
        [SerializeField]
        private bool _isGizmosPoint = true;
        [SerializeField]
        private Color _GizmosColorPoint = Color.green;
        [SerializeField]
        private float _radius = 0.1f;


        private Transform nextPoint;

        private void OnDrawGizmos()
        {
            if (_isGizmosPoint)
            {
                Gizmos.color = _GizmosColorPoint;
                Gizmos.DrawSphere(transform.position, _radius);
            }

            if (_isGizmosBetweenPoints)
            {
                if (transform.parent == null)
                {
                    Debug.LogError("There is no parent for this point");
                    return;
                }

                if (!isLooping && transform.parent.childCount - 1 == transform.GetSiblingIndex())
                    return;

                nextPoint = NextChild();
                if (nextPoint == null)
                    return;

                Gizmos.color = _GizmosColorBetweenPoints;
                Gizmos.DrawLine(transform.position, nextPoint.position);
            }

        }

        private Transform NextChild()
        {
            int thisIndex = transform.GetSiblingIndex();

            if (transform.parent == null)
                return null;

            if (transform.parent.childCount <= thisIndex + 1)
                return transform.parent.GetChild(0).transform;

            return transform.parent.GetChild(thisIndex + 1).transform;
        }
    }
}