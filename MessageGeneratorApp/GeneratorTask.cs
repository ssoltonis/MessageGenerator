using MessageGeneratorApp.DAL;
using MessageGeneratorApp.DataModels;
using MessageGeneratorApp.Helpers;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MessageGeneratorApp
{
    public class GeneratorTask
    {
        #region Private parameters

        private GeneratorStatus _generatorStatus;
        
        private delegate void GeneratorDelegate();

        private AccessDb _dataBase;

        private int _number;

        #endregion

        #region Public parameters

        public delegate void StatusEventHandler(object sender, GeneratorEventArgs e);

        public delegate void ProgressEventHandler(object sender, GeneratorEventArgs e);

        public event StatusEventHandler StatusChanged;

        public event ProgressEventHandler ProgressChanged;
        
        public GeneratorStatus Status
        {
            get { return _generatorStatus; }
        }
        
        #endregion
        
        /// <summary>
        /// Konstruktorius
        /// </summary>
        /// <param name="dataBase">Duomenų bazės objektas</param>
        public GeneratorTask(AccessDb dataBase, int number)
        {
            _dataBase = dataBase;
            _number = number;
        }

        public void StartGenerate()
        {
            lock( this )
            {
                if (_generatorStatus == GeneratorStatus.Stopped)
                {
                    GeneratorDelegate del = new GeneratorDelegate(GenerateMessage);
                    del.BeginInvoke(new AsyncCallback(EndGenerate), del);

                    _generatorStatus = GeneratorStatus.Started;
                    
                    // Atnaujina UI būseną
                    FireStatusChangedEvent(_generatorStatus);
                }
            }
        }

        public void StopGenerate()
        {
            lock (this)
            {
                if (_generatorStatus == GeneratorStatus.Started)
                {
                    _generatorStatus = GeneratorStatus.StopPending;

                    // atnaujina UI būseną
                    FireStatusChangedEvent(_generatorStatus);
                }
            }
        }

        private void GenerateMessage()
        {
            while (_generatorStatus != GeneratorStatus.StopPending)
            {
                // formuojama eilutė
                var msg = StringHelper.CreateString(_number);
                
                MessageData md = new MessageData
                { ThreadID = _number,
                  Time = DateTime.Now,
                  Message = msg
                };

                // saugo duomenis į DB
                var saved = _dataBase.InsertNewRecord(md);
                if (saved)
                {
                    // perduoda sugeneruotą pranešimą į UI
                    FireProgressChangedEvent(md);
                }

                // laukia...
                Thread.Sleep(new Random().Next(500, 2000));
            }
        }
        
        private void EndGenerate(IAsyncResult ar)
        {
            GeneratorDelegate del = (GeneratorDelegate)ar.AsyncState;
            del.EndInvoke(ar);

            lock (this)
            {
                _generatorStatus = GeneratorStatus.Stopped;
                
                // atnaujina UI būseną
                FireStatusChangedEvent(_generatorStatus);
            }
        }
        
        private void FireStatusChangedEvent(GeneratorStatus status)
        {
            if (StatusChanged != null)
            {
                GeneratorEventArgs args = new GeneratorEventArgs(status);
                if (StatusChanged.Target is Control)
                {
                    Control targetForm = StatusChanged.Target as Control;
                    targetForm.Invoke(StatusChanged, new object[] { this, args });
                }
                else
                {
                    StatusChanged(this, args);
                }
            }
        }

        private void FireProgressChangedEvent(MessageData messageData)
        {
            if (ProgressChanged != null)
            {
                GeneratorEventArgs args = new GeneratorEventArgs(messageData);
                if (ProgressChanged.Target is Control)
                {
                    Control targetForm = ProgressChanged.Target as Control;
                    targetForm.Invoke(ProgressChanged, new object[] { this, args });
                }
                else
                {
                    ProgressChanged(this, args);
                }
            }
        }
    }
}
