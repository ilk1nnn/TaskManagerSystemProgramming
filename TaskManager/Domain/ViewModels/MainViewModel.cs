using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TaskManager.Data_Access.Entities;
using TaskManager.Domain.Commands;

namespace TaskManager.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private ObservableCollection<Process> allProcesses;

        public ObservableCollection<Process> AllProcesses
        {
            get { return allProcesses; }
            set { allProcesses = value; OnPropertyChanged(); }
        }


        private TextBox processNameTxtb;

        public TextBox ProcessNameTxtb
        {
            get { return processNameTxtb; }
            set { processNameTxtb = value; OnPropertyChanged(); }

        }


        private string nameProcess;

        public string NameProcess
        {
            get { return nameProcess; }
            set { nameProcess = value; OnPropertyChanged(); }
        }




        private ObservableCollection<string> allBlackBoxProcesses;

        public ObservableCollection<string> AllBlackBoxProcesses
        {
            get { return allBlackBoxProcesses; }
            set { allBlackBoxProcesses = value; OnPropertyChanged(); }
        }


        public RelayCommand CreateCommand { get; set; }
        public RelayCommand EndCommand { get; set; }
        public RelayCommand AddToBlackBoxCommand { get; set; }


        private Process selectedProcess;

        public Process SelectedProcess
        {
            get { return selectedProcess; }
            set { selectedProcess = value; OnPropertyChanged(); }
        }


        public RelayCommand SelectedProcessCommand { get; set; }



        public MainViewModel()
        {

            AllProcesses = new ObservableCollection<Process>();
            AllBlackBoxProcesses = new ObservableCollection<string>();


            var ap = Process.GetProcesses().ToList();


            foreach (var item in ap)
            {

                AllProcesses.Add(item);
            }


            AddToBlackBoxCommand = new RelayCommand(a =>
            {
                if (selectedProcess != null)
                {
                    try
                    {
                        NameProcess = SelectedProcess.ProcessName;
                        AllBlackBoxProcesses.Add(NameProcess.ToLower());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Process");
                }
            });


            CreateCommand = new RelayCommand(c =>
            {

               
                    if (AllBlackBoxProcesses.Contains(processNameTxtb.Text.ToLower()))
                    {
                        MessageBox.Show($"{processNameTxtb.Text} can't create task,because this process is in black box!");
                    }
                    else
                    {
                        var name = processNameTxtb.Text;
                        var newProcess = Process.Start(name);
                        AllProcesses.Add(newProcess);
                    }
            });


            EndCommand = new RelayCommand(e =>
            {



                if (selectedProcess != null)
                {
                    try
                    {
                        SelectedProcess.Kill();
                        AllProcesses.Remove(selectedProcess);
                        MessageBox.Show($"Process ends Successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Process");
                }

            });



        }


    }
}
