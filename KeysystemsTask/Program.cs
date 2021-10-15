using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace KeysystemsTask
{
  public struct Data
  {
    public int a;
    public int b;
  }
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1(GetData()));
    }

    static Data[] GetData()
    {
      Random rnd = new Random();
      int randMax = int.MaxValue;
      int randMin = int.MinValue;
      Data[] s_source = new Data[1000];
      for (int i = 0; i < 1000; i++)
      {
        s_source[i].a = rnd.Next(randMin, randMax);
        s_source[i].b = rnd.Next(randMin, randMax);
      }
      return s_source;
    }
  }
}
