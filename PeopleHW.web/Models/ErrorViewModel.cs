using PeopleHW.Data;
using System;
using System.Collections.Generic;

namespace PeopleHW.web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class PersonViewModel
    {
        public List<Person> people { get; set; }
        public string Message { get; set; }
    }
}
