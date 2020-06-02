using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {

        /*private static Camera _camera;*/
        

 /*       static GameAreaHelper()
        {
            _camera = Camera.main;  // убрал потому что при рестарте сцены возникали потери камеры
        }*/

        
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds,Camera _camera)// перенес инициализацию камеры в параметры
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);

        }
        
    }
}
