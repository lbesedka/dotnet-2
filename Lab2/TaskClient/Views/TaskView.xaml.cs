﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskClient.ViewModel;

namespace TaskClient.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskView.xaml
    /// </summary>
    public partial class TaskView : Window
    {
        public TaskView()
        {
            InitializeComponent();
        }

        public TaskView(TaskViewModel taskViewModel)
        {
            InitializeComponent();
            DataContext = taskViewModel;
        }
    }
}
