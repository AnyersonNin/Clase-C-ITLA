﻿
namespace InfrastructureLayer.Repositorio.Comun
{
    public interface IProcesoComun <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetCompletasAsync();
        Task<double> GetPromedioCompletasAsync();
        Task<IEnumerable<T>> GetPendientesAsync();
        Task<T> GetIdAsync(int id);
        Task<(bool IsSucces,string Message)>AddAsync(T entry);
        Task<(bool IsSucces, string Message)> UpdateAsync(T entry);
        Task<(bool IsSucces, string Message)> DeleteAsync(int id);
    
    }
}
