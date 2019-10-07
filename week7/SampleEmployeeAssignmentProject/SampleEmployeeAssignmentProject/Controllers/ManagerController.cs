using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SampleEmployeeAssignmentProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {

        public class Employee
        {
            public int managerId;
            public int id;
            public string name;
        }

        public class Manager
        {
            public int id;
            public string name;
            public Employee empDetails;
        }

        List<Manager> manager_list = new List<Manager>();

        public ManagerController()
        {
            for (int index = 0; index < 10; ++index)
            {
                manager_list.Add(new Manager()
                {
                    id = index,
                    name = "generic manager name " + index,
                    empDetails = new Employee()
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
        public List<Manager> Get()
        {
            return this.manager_list;
        }

        // GET manager/{id}
        [HttpGet("{id}")]
        public Manager Get(int id)
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


        [HttpPost]
        public IActionResult Post([FromBody] Manager empData)
        {
            manager_list.Add(new Manager
            {
                id = empData.id,
                name = empData.name,
                empDetails = new Employee()
                {
                    managerId = empData.empDetails.managerId,
                    id = empData.empDetails.id,
                    name = empData.empDetails.name
                }
            });
            return Ok(empData);
        }
    }
}
