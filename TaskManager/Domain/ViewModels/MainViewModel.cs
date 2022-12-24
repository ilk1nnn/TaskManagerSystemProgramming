using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

		private ObservableCollection<ProcessModel> allProcesses;

		public ObservableCollection<ProcessModel> AllProcesses
        {
			get { return allProcesses; }
			set { allProcesses = value; OnPropertyChanged(); }
		}


		public MainViewModel()
		{

			AllProcesses = new ObservableCollection<ProcessModel>();


		}


	}
}
