using MessageGeneratorApp.DAL;
using MessageGeneratorApp.DataModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MessageGeneratorApp
{
    public partial class MainForm : Form
    {
        private static IList<GeneratorTask> _taskList;
        
        private AccessDb _dataBase;
        
        public MainForm()
        {
            InitializeComponent();

            _taskList = new List<GeneratorTask>();
            _dataBase = new AccessDb();
        }

        private void OnGeneratorProgressChanged(object sender, GeneratorEventArgs e)
        {
            if (e.Data == null)
                return;
            
            if (e.Data.ThreadID != 0 && !string.IsNullOrEmpty(e.Data.Message))
            {
                // trinamas pirmas įrašas
                if (lstvResults.Items.Count == 20)
                {
                    lstvResults.Items.RemoveAt(0);
                }

                var item = new ListViewItem(new[] { e.Data.ThreadID.ToString(), e.Data.Message });
                lstvResults.Items.Add(item);
            }
            
        }

        private void OnGeneratorStatusChanged(object sender, GeneratorEventArgs e)
        {
            CheckStatus();
        }

        private void CheckStatus()
        {
            var started = false;
            var stopping = false;

            foreach (var task in _taskList)
            {
                if (task.Status == GeneratorStatus.Started)
                {
                    started = true;
                }
                else if (task.Status == GeneratorStatus.StopPending)
                {
                    stopping = true;
                }
            }

            if (stopping)
            {
                btnStart.Enabled = false;
                numThreadCount.Enabled = false;
                btnStop.Enabled = false;
            }
            else
            {
                if (started)
                {
                    btnStart.Enabled = false;
                    numThreadCount.Enabled = false;
                    btnStop.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = true;
                    numThreadCount.Enabled = true;
                    btnStop.Enabled = false;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _taskList.Clear();
            lstvResults.Items.Clear();

            // sukuriama duomenų lentelė
            _dataBase.CreateTable();

            // sukuriami skirtingi procesai (gijos)
            CreateTasks(this.numThreadCount.Value);
        }
        
        private void CreateTasks(decimal value)
        {
            for (int i = 0; i < value; i++)
            {
                var task = new GeneratorTask(_dataBase, i+1);
                task.StatusChanged += new GeneratorTask.StatusEventHandler(OnGeneratorStatusChanged);
                task.ProgressChanged += new GeneratorTask.ProgressEventHandler(OnGeneratorProgressChanged);

                _taskList.Add(task);
            }

            // paleidžiami procesai
            RunTasks();
        }

        private void RunTasks()
        {
            foreach (var task in _taskList)
            {
                task.StartGenerate();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            foreach (var task in _taskList)
            {
                task.StopGenerate();
            }
        }
    }
}
