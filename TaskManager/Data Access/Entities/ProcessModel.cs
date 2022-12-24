using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data_Access.Entities
{
    public class ProcessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Machine { get; set; }
        public int HandleCount { get; set; }
        public Process Process { get; set; }

        public ProcessModel(Process process)
        {
            Process= process;
            Id = process.Id;
            Name = process.ProcessName;
            Machine = process.MachineName;
            HandleCount = process.HandleCount;
        }

    }
}
