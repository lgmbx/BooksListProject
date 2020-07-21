using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Models {
    public class BookFormViewModel {

        public Book Book { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
