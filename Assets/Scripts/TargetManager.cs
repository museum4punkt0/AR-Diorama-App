using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TargetManager : MonoBehaviour {
    [SerializeField] private GameObject trackedImagePrefab;

    private bool _prefabSpawned;
    private GameObject _prefabInstance;
    private bool updated=false;
    private int count=0;
    
    // Start is called before the first frame update
    void Start() {
        GetComponent<ARTrackedImageManager>().trackedImagesChanged += OnTrackedImagesChanged;
    }
    

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args) {
        if (args.added.Count > 0 && !_prefabSpawned) {
            var trackedImage = args.added[0].transform;
            _prefabInstance = Instantiate(trackedImagePrefab, trackedImage.position, trackedImage.rotation);
            _prefabSpawned = true;
           
        }

        if (!updated && args.updated.Count > 0 && _prefabSpawned) {
            var updatedImage = args.updated[0].transform;
            _prefabInstance.transform.position = updatedImage.position;
            _prefabInstance.transform.rotation = updatedImage.rotation;
            count += 1;
            if (count > 2)
            {
                updated = true;
            }
        }
    }

    public void newScan()
    {
        updated = false;
        count = 0;
    }
}
