using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Für den Linksklick
using UnityEngine.XR.ARFoundation; // Für AR-Funktionen
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARSpawner : MonoBehaviour
{
    // stellt das zu Spawnen Objekt ein
    [Header("Spawner Einstellungen")]
    [SerializeField] private GameObject prefabToSpawn;

 // stellt die Skalierung ein 
    [Header("Skalierung")]
    [SerializeField] private Vector3 customScale = new Vector3(1f, 1f, 1f);

    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        // holt den arRaycastManager von diesem GameObject
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // wenn maus erkannt und linksklick erkannt
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            //position der Maus wird auf dem bildschirm gelesen
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            // raycast wird in richtung  der mausposition gesendet,
            // hits werden  in der hits liste gespeichert
            // es werden nur hits an AR-Flächen erkannt
            if (arRaycastManager.Raycast(mousePosition, hits, TrackableType.PlaneWithinPolygon))
            {

                Pose hitPose = hits[0].pose;

                Debug.Log("Plane getroffen ");

                // lässt ein prefab an der ausgewählten position und rotation spawnen
                GameObject newObject = Instantiate(prefabToSpawn, hitPose.position, hitPose.rotation);
                
                newObject.transform.localScale = customScale;
            }
            else
            {
                Debug.Log("Keine AR-Fläche an dieser Stelle erkannt.");
            }
        }
    }
}