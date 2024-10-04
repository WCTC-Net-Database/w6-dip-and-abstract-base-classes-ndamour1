using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6_assignment_template.Interfaces
{
    public interface IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IRoom North { get; set; }
        public IRoom South { get; set; }
        public IRoom East { get; set; }
        public IRoom West { get; set; }

        public void Enter(IRoom room);
    }
}
