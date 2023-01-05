using BAckendApi.Models;
using BAckendApi.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BAckendApi.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private DbempleadoContext _dbContext;

        public EmpleadoService(DbempleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Empleado> Add(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Empleado> Get(int idEmpleado)
        {
            try
            {
                Empleado? encontrado = new();
                encontrado = await _dbContext.Empleados.Include(x => x.IdDepartamentoNavigation)
                    .Where(e => e.IdEmpleado == idEmpleado).FirstOrDefaultAsync();
                return encontrado;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Empleado>> GetList()
        {
            try
            {
                List<Empleado> lista = new();
                lista = await _dbContext.Empleados.Include(x => x.IdDepartamentoNavigation).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

