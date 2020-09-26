using UnityEngine;

public class MyNode : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown() {
        if (turret != null) {
            Debug.Log("Can't build there! - TODO: Dispaly on screen.");
            return;
        }

        // Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() {
        rend.material.color = startColor;
    }
}
