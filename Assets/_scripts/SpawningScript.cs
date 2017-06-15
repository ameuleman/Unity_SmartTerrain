using Vuforia;
using UnityEngine;

public class SpawningScript : MonoBehaviour {
    public Transform Cube;  

    public void spawnCube()
    {
        GameObject go = VuforiaManager.Instance.ARCameraTransform.gameObject;
        Camera[] cam = go.GetComponentsInChildren<Camera>();
        Ray ray = cam[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;



        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 spawnPoint = new Vector3(hitInfo.point.x, Cube.position.y, hitInfo.point.z);
            int colliderCount = Physics.OverlapBox(spawnPoint, new Vector3(2, 2, 2), Quaternion.identity).Length;

            if (colliderCount <= 1)
            {
                Transform cubeClone = (Transform)Instantiate(Cube, spawnPoint, Quaternion.identity);
            }
        }
    }
}
