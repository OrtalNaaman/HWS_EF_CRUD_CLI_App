using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HWS_EF_CRUD_CLI_App.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
