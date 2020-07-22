using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Services.Exceptions {
    public class DuplicateItemException : ApplicationException {

        public DuplicateItemException(string message) : base(message) {
        }
    }
}
