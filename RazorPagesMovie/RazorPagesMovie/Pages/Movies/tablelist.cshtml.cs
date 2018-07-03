using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class tablelistModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public tablelistModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }
        public IList<Movie> Movie { get; set; }


        public async Task OnGetAsync(string Searchstring)
        {
            TableListModel model = new TableListModel();

               var movies = from m in _context.Movie
                         select m;
            if (!String.IsNullOrEmpty(Searchstring))
            {
                movies = movies.Where(s => s.Title.Contains(Searchstring));
            }

            Movie= await movies.ToListAsync();

        }

        //public IViewComponentResult Invoke() {

       // }
    }
}