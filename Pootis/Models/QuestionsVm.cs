using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pootis.Models {
    public class QuestionsVm {
        public string[][] Questions { get; set; }
        public int[,] Order { get; set; }
    }
}