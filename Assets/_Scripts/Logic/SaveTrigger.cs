using System;
using _Scripts.Infrastructure.Services;
using _Scripts.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace _Scripts.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        public BoxCollider2D Collider;

        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _saveLoadService.SaveProgress();
            Debug.Log("Progress Saved.");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!Collider)
                return;
            
            Gizmos.color = new Color32(30, 200, 30, 130);
            var position = transform.position;
            Gizmos.DrawCube(new Vector2(position.x, position.y) + Collider.offset, Collider.size);
        }
    }
}