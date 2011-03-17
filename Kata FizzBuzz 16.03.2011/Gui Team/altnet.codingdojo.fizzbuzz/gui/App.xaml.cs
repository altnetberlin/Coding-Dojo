using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;
using Autofac.Builder;
using altnet.codingdojo.fizzbuzz.contract;
using System.IO;

namespace altnet.codingdojo.fizzbuzz.gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.Register<IFizzBuzzService>(new FizzBuzzService());

            Container = builder.Build();
        }

        public static IContainer Container { get; private set; }
    }
}
