using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SampleWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        public class EmployeeData
        {
            public string name;
        }
        // GET sample/
        [HttpGet]
        public List<EmployeeData> Get()
        {
            List<EmployeeData> emp_list_dictionary = new List<EmployeeData>(){
                new EmployeeData(){ name = "generic employee name 1" },
                new EmployeeData(){ name = "generic employee name 2" },
                new EmployeeData(){ name = "generic employee name 3" },
                new EmployeeData(){ name = "generic employee name 4" },
                new EmployeeData(){ name = "generic employee name 5" }
            };

            return emp_list_dictionary;
        }
    }
}
