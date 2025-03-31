using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorApp.Data;
using MyRazorApp.Models;

namespace MyRazorApp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; } // Changed to non-nullable
        
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult OnGet(int? CategoryId)
{
    if (CategoryId == null || CategoryId == 0)
    {
        return NotFound();
    }

    Category = _db.Categories.Find(CategoryId);
    
    if (Category == null)
    {
        return NotFound();
    }
    
    return Page();
}
        
        public IActionResult OnPost()
{
    if (Category == null || Category.CategoryId == 0)
    {
        return NotFound();
    }
    
    var obj = _db.Categories.Find(Category.CategoryId);
    if (obj == null)
    {
        return NotFound();
    }
    
    _db.Categories.Remove(obj);
    _db.SaveChanges();
    TempData["Success"] = "Category deleted successfully!";
    return RedirectToPage("Index");
}
    }
}