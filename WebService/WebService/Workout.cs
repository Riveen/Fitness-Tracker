using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Workout
    {
        public string date { get; set; }
        public string workout { get; set; }
        public string weight { get; set; }
        public string sets { get; set; }
        public string reps { get; set; }
        public string duration { get; set; }
    }
}