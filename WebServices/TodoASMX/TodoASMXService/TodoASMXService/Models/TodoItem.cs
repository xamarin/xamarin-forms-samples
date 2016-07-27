using System;

namespace TodoASMXService.Models
{
    [Serializable]
    public class TodoItem
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public bool Done { get; set; }
    }
}
