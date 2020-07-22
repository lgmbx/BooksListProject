using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Services.Exceptions {
    public class DbCurrencyException : ApplicationException {

        public DbCurrencyException(string message) : base(message) {
        }
    }
}
