using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class DatabaseTest : IDatabaseTest
    {
        private AppDbContext _appDbContext;

        public DatabaseTest(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void DoTest()
        {
            var TodoItem = _appDbContext.TodoItems.FirstOrDefault();
            Console.WriteLine(TodoItem?.Title ?? "Todo not found!");
        }
    }
}
