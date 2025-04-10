using CropWise.Models;
using CropWise.Data;
using System;
using Microsoft.EntityFrameworkCore;

public class CropAnalysisRepository : ICropAnalysisRepository
{
    private readonly CropWiseDbContext _context;

    public CropAnalysisRepository(CropWiseDbContext context)
    {
        _context = context;
    }


    // Get by CropId
    public async Task<CropAnalysis> GetByCropIdAsync(int cropId)
    {
        return await _context.CropAnalyses
                             .FirstOrDefaultAsync(ca => ca.CropId == cropId);
    }

    // Get by AnalysisId
    public async Task<CropAnalysis> GetByIdAsync(int id)
    {
        return await _context.CropAnalyses
                             .FirstOrDefaultAsync(ca => ca.Id == id);
    }

    // Add Crop Analysis
    public async Task<CropAnalysis> AddAsync(CropAnalysis cropAnalysis)
    {
        _context.CropAnalyses.Add(cropAnalysis);
        await _context.SaveChangesAsync();
        return cropAnalysis;
    }

    // Delete Crop Analysis
    public async Task<bool> DeleteAsync(int id)
    {
        var cropAnalysis = await _context.CropAnalyses.FindAsync(id);
        if (cropAnalysis == null)
        {
            return false;  // Return false if not found
        }

        _context.CropAnalyses.Remove(cropAnalysis);
        await _context.SaveChangesAsync();
        return true; // Return true if deleted successfully
    }
}
