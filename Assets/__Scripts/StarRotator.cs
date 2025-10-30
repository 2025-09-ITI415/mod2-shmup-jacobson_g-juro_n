using UnityEngine;

public class StarRotator : MonoBehaviour
{
    [Tooltip("The target (usually the Hero) to orbit around.")]
    public Transform target;

    [Tooltip("How far away from the target the star orbits.")]
    public float orbitRadius = 3f;

    [Tooltip("How fast the star rotates around the target, in degrees per second.")]
    public float orbitSpeed = 180f;

    [Tooltip("Whether the star should also rotate on its own axis.")]
    public float selfSpinSpeed = 90f;

    private float angle; // internal orbit angle tracker

    void Update()
    {
        if (target == null) return;

        // Increment the angle based on orbitSpeed
        angle += orbitSpeed * Time.deltaTime;
        if (angle > 360f) angle -= 360f;

        // Calculate the orbit position around the target (XY plane)
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;

        // Update position
        transform.position = target.position + offset;

    }
}
