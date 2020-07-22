using System;

namespace BooksListMvc2.Services.Exceptions {
    public class NotFoundException : ApplicationException {

        public NotFoundException(string message) : base(message) {
        }
    }
}
