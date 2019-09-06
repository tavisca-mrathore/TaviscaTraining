using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SampleEmployeeAssignmentProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        List<ManagerData> manager_list = new List<ManagerData>();

        public class EmployeeData
        {
            public int managerId;
            public int id;
            public string name;
        }

        public class ManagerData
        {
            public int id;
            public string name;
            public EmployeeData empDetails;
        }

        public ManagerController()
        {
            for (int index = 0; index < 10; ++index)
            {
                manager_list.Add(new ManagerData()
                {
                    id = index,
                    name = "generic manager name " + index,
                    empDetails = new EmployeeData()
                    {
                        managerId = index,
                        id = 100 + index,
                        name = "generic employee name " + index
                    }
                });
            }
        }

        // GET manager/
        [HttpGet]
        public List<ManagerData> Get()
        {
            return this.manager_list;
        }

        // GET manager/{id}
        [HttpGet("{id}")]
        public ManagerData Get(int id)
        {
            for (int index = 0; index < 10; ++index)
            {
                if (this.manager_list[index].id == id)
                {
                    return this.manager_list[index];
                }
            }
            return null;
        }
    }
}
