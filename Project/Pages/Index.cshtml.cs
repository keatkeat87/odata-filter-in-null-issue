using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Project.Entity;

namespace Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet([FromServices] CustomerOrderContext Db)
        {
            Db.Products.Add(new Product
            {
                name = "mk100",
            });
            Db.Products.Add(new Product
            {
                name = "mk200",
            });
            Db.Products.Add(new Product
            {
                name = "mk300",
            });
            Db.Products.Add(new Product
            {
                name = null,
            });
            Db.Products.Add(new Product
            {
                name = null,
            });

            Db.SaveChanges();
        }
    }
}
