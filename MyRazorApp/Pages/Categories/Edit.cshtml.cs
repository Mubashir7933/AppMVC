using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorApp.Data;
using MyRazorApp.Models;

namespace MyRazorApp.Pages.Categories
{
    [BindProperties]
public class EditModel: PageModel
{
     private readonly ApplicationDbContext _db;
        //  [BindProperty]// Connecting Post method to Category Handler Obj 
        public Category? Category {get; set;}
         public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? CategoryId)
        {
            if(CategoryId!=null && CategoryId!=0){

Category = _db.Categories.Find(CategoryId);
            }
        }
        public IActionResult OnPost (){
           if(ModelState.IsValid){

            _db.Categories.Update(Category);
            _db.SaveChanges();
            TempData["Success"] = "Category Updated Successfully";
            return RedirectToPage("Index");
            }
            return Page();
        }
}
}