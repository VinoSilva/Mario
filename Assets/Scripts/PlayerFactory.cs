using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject marioPrefab = null;

    [SerializeField]
    private GameObject playerCamera = null;

    [SerializeField]
    private CinemachineVirtualCamera virtualCamera= null; 

    private GameObject spawnedPlayer = null;

    private GameObject spawnedCamera = null;

    private void OnEnable()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        spawnedPlayer = Instantiate(marioPrefab,transform.position,marioPrefab.transform.rotation) as GameObject;

        // Spawn camera
        Vector3 cameraSpawnPosition = spawnedPlayer.transform.position;
        cameraSpawnPosition.z = -10;
        spawnedCamera = Instantiate(playerCamera,cameraSpawnPosition,playerCamera.transform.rotation) as GameObject;

        virtualCamera.Follow = spawnedPlayer.transform;

        virtualCamera.gameObject.transform.parent = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}
