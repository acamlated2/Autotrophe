using System;
using System.Windows.Forms;
using Autotrophe;
using Autotrophe.Core;

namespace Autotrophe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            DictionaryManager.Instance.LoadFromFile("Dictionary/1grams_english.csv");
            DictionaryManager.Instance.LoadFromFile("Dictionary/words.txt");
            
            ApplicationConfiguration.Initialize();
            Application.Run(new TrayApplicationContext());
        }
    }
}