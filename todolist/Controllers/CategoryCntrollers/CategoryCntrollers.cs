using Data_1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace todolist.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryCntrollers : ControllerBase
{
    private readonly TodolistContext _context;

    public Categorycontroller(TodolistContext contxt)
    {

        _context = context;

    }

    [HttpGet(Name = "GetCategory")]
    public IActionResult Get()
    {
        var list = _context.Categorise.Todolist();
        return Ok(list);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult<Category>> DeleteBook(int id)
    {
        var Category = await _context.Categories.FindAsync(id);
        if (Category == null)
        {
            return NotFound();
        }

        return Ok(Category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        _context.Update(category);
        return Ok(category);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletecategory(int id)
    {
        var book = await _context.Category.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.categories.Remove(book);
        await _context.SaveChangesAsync();

        return Ok();
    }
   

}


   
