using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.WorkplacesDTOs;
using JiraCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkplaceController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkplaceController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("createWorkplace")]

    public async Task<IActionResult> CreateWorkplace([FromBody] CreateWorkplaceDTO workplaceDTO)
    {
        var workplaces = new Workplace();

        workplaces.WorkplaceName = workplaceDTO.WorkplaceName;
        workplaces.WorkplaceAdminId = workplaceDTO.WorkplaceAdminId;
        
        await _context.Workplaces.AddAsync(workplaces);
        await _context.SaveChangesAsync();
        
        return Ok(workplaces);
        
    }


    [HttpGet("listWorkplaces")]

    public async Task<IActionResult> GetWorkplaces()
    {
        var workplaces = _context.Workplaces.ToList();
        return Ok(workplaces);
    }

    [HttpGet("getWorkplaces/{workplaceAdminId}")]
    public async Task<IActionResult> GetWorkplaces(int workplaceAdminId)
    {
        var workplace = _context.Workplaces.Where(w => w.WorkplaceAdminId == workplaceAdminId).ToList();
        return Ok(workplace);
    }
    
    [HttpPut("updateWorkplace")]
    public async Task<IActionResult> UpdateWorkplace([FromBody] UpdateWorkplaceDTO workplaceDTO)
    {
        // Güncellenecek workplace'ı bul
        var workplace = await _context.Workplaces.FindAsync(workplaceDTO.Id);
        if (workplace == null)
        {
            return NotFound(); // Eğer workplace bulunamazsa 404 döner
        }

        // Workplace'ın adını güncelle
        workplace.WorkplaceName = workplaceDTO.WorkplaceName;

        // Değişiklikleri kaydet
        await _context.SaveChangesAsync();

        return Ok(workplace); // Güncellenen workplace'ı döner
    }

    [HttpDelete("deleteWorkplaces/{id}")]
    public async Task<IActionResult> DeleteWorkplace(int id)
    {
        // İşyerini ID ile bul
        var workplace = await _context.Workplaces.FindAsync(id);

        // Eğer işyeri bulunamazsa, 404 Not Found döndür
        if (workplace == null)
        {
            return NotFound(new { message = "Workplace not found." });
        }

        // İşyerini sil
        _context.Workplaces.Remove(workplace);
    
        // Değişiklikleri kaydet
        await _context.SaveChangesAsync();

        // Başarılı bir yanıt döndür
        return Ok(new { message = "Workplace successfully deleted." });
    }

}
