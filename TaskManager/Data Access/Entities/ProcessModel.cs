using System;
using System.Collections.Generic;
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

    }
}
