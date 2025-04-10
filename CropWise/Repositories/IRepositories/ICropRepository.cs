using System.Collections.Generic;
using System.Threading.Tasks;
using CropWise.Models;

public interface ICropRepository
{
    Task<IEnumerable<Crop>> GetAllAsync();
    Task<Crop?> GetByIdAsync(int id);
    Task AddAsync(Crop crop);
    Task UpdateAsync(Crop crop);
    Task DeleteAsync(int id);
}
