using System;
using UnityEngine;
using UnityEngine.UI;

namespace InteractablesObjects.InteractablesObject{
    public class BinOti : ObjectsToInteract{
        [SerializeField] private CanvasGroup miniGameStartMenu;
        [SerializeField] private CanvasGroup scoreBoardUI;
        [SerializeField] private Transform player;
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        
        private RectTransform startMenuTransform;
        private bool isCanvasGroupOpen = false;

        private void Start(){
            startMenuTransform = miniGameStartMenu.GetComponent<RectTransform>();
            exitButton.onClick.AddListener(StartMenuCanvasGroupEnabler);
        }

        private void Update(){
            if (isCanvasGroupOpen){
                startMenuTransform.LookAt(player);
            }
        }

        public void StartMenuCanvasGroupEnabler(){
            if (!isCanvasGroupOpen){
                miniGameStartMenu.alpha = 1;
                miniGameStartMenu.interactable = true;
                miniGameStartMenu.blocksRaycasts = true;
                isCanvasGroupOpen = true;
            }else if (isCanvasGroupOpen){
                miniGameStartMenu.alpha = 0;
                miniGameStartMenu.interactable = false;
                miniGameStartMenu.blocksRaycasts = false;
                isCanvasGroupOpen = false;
            }
        }

    }
}