using StaticData;
using UnityEngine;

namespace Infrastructure
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Target[] _targets;
    
        private StaticDataService _staticDataService;

        private void Awake()
        {
            _staticDataService = new StaticDataService();
            _staticDataService.LoadData();
        
            Initialize();
        }

        private void Initialize()
        {
            _spawner.Initialize(_staticDataService);

            foreach (Target target in _targets) 
                target.Initialize(_staticDataService);
        }
    }
}