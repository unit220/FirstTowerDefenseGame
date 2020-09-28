using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake() {
        if (instance != null) {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }


    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn (MyNode node) {
        // Build a turret
        //GameObject turretToBuild = buildManager.GetTurretToBuild();
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
    }
}
