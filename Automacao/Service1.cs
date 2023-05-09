using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Timer = System.Timers.Timer;

namespace Automacao
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
                // Cria um timer com intervalo de X horas/minutos e por vai
                timer = new Timer(4 * 60 * 1000);
                timer.Elapsed += OnTimedEvent;
                timer.AutoReset = true;
                timer.Enabled = true;
        }

        protected override void OnStop()
        {
                timer.Dispose();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
                // Coloque aqui o comando que você quer executar a cada X horas
                // Por exemplo:
                string origem = @"C:\Users\03461471232\Documents\Arquivosparaler";
                string destino = @"D:\Nova pasta";

                Directory.CreateDirectory(destino);

                foreach (string dirPath in Directory.GetDirectories(origem, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(origem, destino));

                foreach (string filePath in Directory.GetFiles(origem, ".", SearchOption.AllDirectories))
                    File.Copy(filePath, filePath.Replace(origem, destino), true);     
        }
    }
}

