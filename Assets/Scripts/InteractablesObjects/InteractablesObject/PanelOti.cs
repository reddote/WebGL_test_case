using UnityEngine;

namespace InteractablesObjects.InteractablesObject{
    public class PanelOti : ObjectsToInteract{
        private Transform panelTransform;

        private void Start(){
            panelTransform = transform;
        }

        public void TurnUpsideDownThePanel(){
            var _rotation = panelTransform.rotation;
            panelTransform.rotation = Quaternion.Euler(new Vector3(
                _rotation.x,
                90f,
                180f));
        }
    }
}
