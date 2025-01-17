﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using TaskClient.Commands;

namespace TaskClient.ViewModel
{
    public class ExecutorsViewModel : INotifyPropertyChanged
    {
        private TaskRepositoryClient _taskRepository;
        public ObservableCollection<ExecutorViewModel> Executors { get; } = new ObservableCollection<ExecutorViewModel>();

        private ExecutorViewModel _selectExecutor;

        public ExecutorsViewModel()
        {
            OpenMainWindowCommand = new Command(commandParameter =>
            {
                var window = (Window)commandParameter;
                window.Hide();
                var mainWindow = window.Owner;
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
            }, null);
            SelectExecutorCommand = new Command(commandParameter =>
            {
                var window = (Window)commandParameter;
                window.DialogResult = true;
                window.Close();
            }, (obj) => Mode == "Select");
            CancelExecutorCommand = new Command(commandParameter =>
            {
                var window = (Window)commandParameter;
                window.DialogResult = false;
                window.Close();
            }, (obj) => Mode == "Select");
        }

        public ExecutorViewModel SelectedExecutor
        {
            get => _selectExecutor;
            set
            {
                if (value == _selectExecutor)
                {
                    return;
                }

                _selectExecutor = value;
                OnPropertyChanged(nameof(SelectedExecutor));
            }
        }

        public async System.Threading.Tasks.Task InitializeAsync(TaskRepositoryClient taskRepository)
        {
            _taskRepository = taskRepository;

            var executors = await _taskRepository.GetExecutorsAsync();
            foreach (var executor in executors)
            {
                ExecutorViewModel executorViewModel = new ExecutorViewModel();
                await executorViewModel.InitializeAsync(_taskRepository, executor.ExecutorId);
                Executors.Add(executorViewModel);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command OpenMainWindowCommand { get; }
        public Command SelectExecutorCommand { get; }
        public Command CancelExecutorCommand { get; }
        public string Mode { get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
