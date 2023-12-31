﻿using System.Linq;
using System.Threading.Tasks;
using BookLogger.Data;
using BookLogger.Models;
using BookLogger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IPublisherService _publisherService;

    public PublishersController(AppDbContext context, IPublisherService publisherService)
    {
        _context = context;
        _publisherService = publisherService;
    }

    // GET: api/Publishers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
    {
        return await _context.Publishers.ToListAsync();
    }

    // GET: api/Publishers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Publisher>> GetPublisher(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);

        if (publisher == null)
        {
            return NotFound();
        }

        return publisher;
    }

    // PUT: api/Publishers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPublisher(int id, Publisher publisher)
    {
        if (id != publisher.PublisherId)
        {
            return BadRequest();
        }

        _context.Entry(publisher).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PublisherExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Publishers
    [HttpPost]
    public async Task<ActionResult<Publisher>> PostPublisher(Publisher publisher)
    {
        _context.Publishers.Add(publisher);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPublisher", new { id = publisher.PublisherId }, publisher);
    }

    // DELETE: api/Publishers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePublisher(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher == null)
        {
            return NotFound();
        }

        _context.Publishers.Remove(publisher);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id}/books")]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooksByPublisherId(int id)
    {
        var books = await _publisherService.GetBooksByPublisherId(id);
        if (books == null)
        {
            return NotFound();
        }
        return Ok(books);
    }

    private bool PublisherExists(int id)
    {
        return _context.Publishers.Any(e => e.PublisherId == id);
    }
}
