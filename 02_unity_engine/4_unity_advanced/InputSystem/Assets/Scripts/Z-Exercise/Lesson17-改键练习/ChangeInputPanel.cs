using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

namespace Z_Exercise.Lesson17_改键联系1_记录改键信息
{
    public enum BTN_TYPE
    {
        UP,DOWN,LEFT,RIGHT,FIRE,JUMP
    }
    
    public class ChangeInputPanel : MonoBehaviour
    {
        public Text textUp;
        public Text textDown;
        public Text textLeft;
        public Text textRight;
        public Text textFire;
        public Text textJump;

        public Button btnUp;
        public Button btnDown;
        public Button btnLeft;
        public Button btnRight;
        public Button btnFire;
        public Button btnJump;

        private InputInfo inputInfo;
        
        private BTN_TYPE nowType;

        public PlayerLesson17 PlayerLesson17;

        private void Start()
        {
            inputInfo = DataManager.Instance.InputInfo;
            UpdateButtonInfo();
            
            btnUp.onClick.AddListener(() =>
            {
                ChangeButton(BTN_TYPE.UP);
            });
            btnDown.onClick.AddListener(() =>
            {
                ChangeButton(BTN_TYPE.DOWN);
            });
            btnLeft.onClick.AddListener(() =>
            {
                ChangeButton(BTN_TYPE.LEFT);
            });
            btnRight.onClick.AddListener(() =>
            {
                ChangeButton(BTN_TYPE.RIGHT);
            });
            btnFire.onClick.AddListener(() =>
            {
                ChangeButton(BTN_TYPE.FIRE);
            });
            btnJump.onClick.AddListener(() =>
            {
                ChangeButton(BTN_TYPE.JUMP);
            });
        }

        private void ChangeButton(BTN_TYPE type)
        {
            nowType = type;
            
            InputSystem.onAnyButtonPress.CallOnce(ChangeButtonReally);
        }

        private void ChangeButtonReally(InputControl obj)
        {
            var strs = obj.path.Split("/");
            var path = $"<{strs[1]}>/{strs[2]}";
            
            switch (nowType)
            {
                case BTN_TYPE.UP:
                    inputInfo.up = path;
                    break;
                case BTN_TYPE.DOWN:
                    inputInfo.down = path;
                    break;
                case BTN_TYPE.LEFT:
                    inputInfo.left = path;
                    break;
                case BTN_TYPE.RIGHT:
                    inputInfo.right = path;
                    break;
                case BTN_TYPE.FIRE:
                    inputInfo.fire = path;
                    break;
                case BTN_TYPE.JUMP:
                    inputInfo.jump = path;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(nowType), nowType, null);
            }

            UpdateButtonInfo();
            
            PlayerLesson17.ChangeInput();
        }

        private void UpdateButtonInfo()
        {
            textUp.text = inputInfo.up;
            textDown.text = inputInfo.down;
            textLeft.text = inputInfo.left;
            textRight.text = inputInfo.right;
            textFire.text = inputInfo.fire;
            textJump.text = inputInfo.jump;
        }
    }
}
