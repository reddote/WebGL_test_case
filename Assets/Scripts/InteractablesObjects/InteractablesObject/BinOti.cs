using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace InteractablesObjects.InteractablesObject{
    public class BinOti : ObjectsToInteract{
        [SerializeField] private CanvasGroup miniGameStartMenu;
        [SerializeField] private CanvasGroup scoreBoardUI;
        [SerializeField] private TextMeshProUGUI[] leadboardText;
        //its calculate time for playing minigame
        [SerializeField] private TextMeshProUGUI timerText;
        private float timeToPlay = 0;
        //how many objects left for the finish game
        [SerializeField] private TextMeshProUGUI countText;
        
        [SerializeField] private Transform player;
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        public bool isGameStarted = false;
        
        private RectTransform startMenuTransform;
        private bool isCanvasGroupOpen = false;

        private void Start(){
            startMenuTransform = miniGameStartMenu.GetComponent<RectTransform>();
            exitButton.onClick.AddListener(StartMenuCanvasGroupEnabler);
            startButton.onClick.AddListener(IsGameStarted);
            startButton.onClick.AddListener(StartMenuCanvasGroupEnabler);
            Spawner.current.isGameFinished += IsGameFinished;
        }

        private void Update(){
            if (isCanvasGroupOpen){
                startMenuTransform.LookAt(player);
            }

            if (isGameStarted){
                TimerCalculate();
            }
        }

        private void IsGameStarted(){
            isGameStarted = true;
            scoreBoardUI.alpha = 1;
        }

        private void IsGameFinished(){
            PlayFabManager.current.SendLeaderBoard(-timeToPlay);
            isGameStarted = false;
            StartCoroutine(DelayForClosingUI());
            timeToPlay = 0;
        }
        
        private void TimerCalculate(){
            timeToPlay += Time.deltaTime;
            string _s = timeToPlay.ToString("N2");
            timerText.text = "" + _s;;
            JavaScriptHook.current.ChangeUITimerTextSet(_s);
        }

        public void CountTextUpdater(int dropCount){
            string _temp = dropCount + "/5";
            countText.text = _temp;
            JavaScriptHook.current.ChangeUICountTextSet(_temp);
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
            SetLeaderBoardList();
        }

        IEnumerator DelayForClosingUI(){
            yield return new WaitForSeconds(2f);
            scoreBoardUI.alpha = 0;
        }

        private void SetLeaderBoardList(){
            var _manager = PlayFabManager.current;
            _manager.isGetLeader = false;
            for (int i = 0; i < _manager.stringLeaderBoard.Count; i++){
                leadboardText[i].text = _manager.stringLeaderBoard[i];
            }
        }
        

    }
}