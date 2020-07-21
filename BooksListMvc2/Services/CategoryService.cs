using BooksListMvc2.Data;
using BooksListMvc2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Services {
    public class CategoryService {

        //injection
        private readonly AppDbContext _dbContext;
        public CategoryService(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        //methods
        public List<Category> FindAll(){
            return _dbContext.Category.OrderBy(x => x.Name).ToList();
        }
    }
}
