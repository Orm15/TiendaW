using CORE.Entities;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	
	public class UsuarioRepository
	{
		private readonly TiendaWebContext _context;

		public UsuarioRepository(TiendaWebContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Usuario>> GetAll()
		{
			return await _context.Usuario.Where(x => x.Estado == true)
				.ToListAsync();
		}

		public async Task<IEnumerable<Usuario>> GetCompradores()
		{
			return await _context.Usuario.Where(x => x.Estado == true && x.Tipo == "compradores")
				.ToListAsync();
		}

		public async Task<IEnumerable<Usuario>> GetVendedores()
		{
			return await _context.Usuario.Where(x => x.Estado == true && x.Tipo == "vendedores")
				.ToListAsync();
		}

		public async Task<Usuario> SignIn(string correo, string contra)
		{
			var usuario =  await _context.Usuario
				.Where(x => x.Estado == true &&
				x.Correo == correo && x.Password == contra)
				.FirstOrDefaultAsync();
			 
			return usuario;
		}

		public async Task<bool> SignUp(Usuario u)
		{
			await _context.Usuario.AddAsync(u);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		} 

		public async Task<bool> Update(Usuario u)
		{
			_context.Usuario.Update(u);
			int rows = await _context.SaveChangesAsync();
			return rows > 0;
		}

		public async Task<bool> ValidateEmail(string correo)
		{
			var usuario = await _context.Usuario.Where(x=>x.Correo == correo)
				.FirstOrDefaultAsync();
			if(usuario == null) return false;
			return true;
		}

		public async Task<bool> Delete(int id)
		{
			var usuario = await _context.Usuario
				.Where(x => x.IdUsuario == id && x.Estado == false)
				.FirstOrDefaultAsync();
			if (usuario == null) return false;

			usuario.Estado = false;
			int rows = await _context.SaveChangesAsync();
			return rows > 0;

		}

	}
}
