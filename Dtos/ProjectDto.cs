using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class ProjectDto
    {
        
        public int IdProject { get; set; }

        
        public string ProjectName { get; set; }

        
        public DateTime StartDate { get; set; }

        
        public DateTime EndDate { get; set; }

        
        public bool IsActive { get; set; }
    }
}
