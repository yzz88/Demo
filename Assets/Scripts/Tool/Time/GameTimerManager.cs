using System;
using System.Collections.Generic;
using Demo.Tool.Singleton;
using UnityEngine;

namespace Demo.Tool.Timer
{

    /// <summary>
    /// 管理所有的计时器
    /// </summary>
    public class GameTimerManager : SingletonMono<GameTimerManager>
    {
        //note:开始的时候我们要创建一些计时器，否则我们的空闲计时器中一个计时器都没有
        //1.有一个集合用来保存所有的空闲计时器
        //2.有一个集合用来保存当前正在工作的计时器
        //3.更新当前工作中的计时器
        //4.当某个计时器工作完成后，我们需要把它回收到空闲计时器集合中

        [SerializeField, Tooltip("初始计时器数量")] private int _initMaxTimerCount; // 初始化最大的空闲计时器数量 

        private Queue<GameTimer> _notWorkerTimer = new Queue<GameTimer>();
        private List<GameTimer> _workeringTimer = new List<GameTimer>();

        private void Start()
        {
            InitTimerManager();
        }

        private void Update()
        {
            UpdateWorkeringTimer();
        }

        private void InitTimerManager()
        {
            for (int i = 0; i < _initMaxTimerCount; i++)
            {
                CreateTimer();
            }
        }

        private void CreateTimer()
        {
            var timer = new GameTimer();
            _notWorkerTimer.Enqueue(timer);
        }

        public void TryUseOneTimer(float time, Action task)
        {
            if (_notWorkerTimer.Count == 0)
            {
                CreateTimer();
                var timer = _notWorkerTimer.Dequeue();
                timer.StartTimer(time, task);
                _workeringTimer.Add(timer);
            }
            else

            {
                var timer = _notWorkerTimer.Dequeue();
                timer.StartTimer(time, task);
                _workeringTimer.Add(timer);
            }
        }

        private void UpdateWorkeringTimer()
        {
            if (_workeringTimer.Count == 0) return;//没有计时器在工作

            //更新当前工作中的计时器
            for (int i = 0; i < _workeringTimer.Count; i++)
            {
                //如果计时器的状态是WORKERING，则更新
                if (_workeringTimer[i].GetTimerState() == E_TimerState.WORKERING)
                {
                    _workeringTimer[i].UpdateTimer();
                }
                else
                {
                    //任务完成
                    _notWorkerTimer.Enqueue(_workeringTimer[i]);//回收
                    _workeringTimer[i].ResetTimer();//重置
                    _workeringTimer.Remove(_workeringTimer[i]);//移除
                }
            }
        }

    }
}
