using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CropWise.Data; // or your actual DbContext namespace
using CropWise.Models;

public class CropRepository : ICropRepository
{
    private readonly CropWiseDbContext _context;

    public CropRepository(CropWiseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Crop>> GetAllAsync()
    {
        return await _context.Crops.ToListAsync();
    }

    public async Task<Crop?> GetByIdAsync(int id)
    {
        return await _context.Crops.FindAsync(id);
    }

    public async Task AddAsync(Crop crop)
    {
        await _context.Crops.AddAsync(crop);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Crop crop)
    {
        _context.Crops.Update(crop);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var crop = await _context.Crops.FindAsync(id);
        if (crop != null)
        {
            _context.Crops.Remove(crop);
            await _context.SaveChangesAsync();
        }
    }
}
