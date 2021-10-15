using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace KeysystemsTask
{
  public partial class Form1 : Form
  {
    Queue<int> _begValueChanging = new Queue<int>();
    int _numHundred = -1;

    public Form1(Data[] source)
    {
      InitializeComponent();
      FillingDGW(source);
      timer.Enabled = true;
    }

    private void FillingDGW(Data[] source)
    {
      foreach (Data unit in source)
      {
        dataGridView1.Rows.Add(unit.a.ToString(), unit.b.ToString());
      }
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      _numHundred = (_numHundred + 1) % 10;
      if (!backgroundWorker.IsBusy)
      {
        backgroundWorker.RunWorkerAsync(_numHundred);
      }
      else
      {
        _begValueChanging.Enqueue(_numHundred);
      }
    }

    private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      Random rnd = new Random();
      int randMax = int.MaxValue;
      int randMin = int.MinValue;
      int begVal = 100 * (int)e.Argument;
      for (int i = begVal; i < begVal + 100; i++)
      {
        dataGridView1[0, i].Value = rnd.Next(randMin, randMax);
        dataGridView1[1, i].Value = rnd.Next(randMin, randMax);
        Thread.Sleep(1);
      }
    }

    private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
      if (_begValueChanging.Count != 0)
      {
        backgroundWorker.RunWorkerAsync(_begValueChanging.Dequeue());
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      backgroundWorker.CancelAsync();
    }
  }
}
