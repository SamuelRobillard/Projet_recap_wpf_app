using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManager.UI.Model
{
    class Idea
    {
        private static int autoincrement = 0;
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Idea()
        {
            autoincrement += 1;
            Id = 1;
        }
    }
}
