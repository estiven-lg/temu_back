using temu_back.Models;
using temu_back.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		private readonly AppDbContext _context;

		public PersonRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Person>> GetAllAsync()
		{
			return await _context.Persons.ToListAsync();
		}

		public async Task<Person?> GetByIdAsync(int id)
		{
			return await _context.Persons.FindAsync(id);
		}

		public async Task<Person> AddAsync(Person person)
		{
			_context.Persons.Add(person);
			await _context.SaveChangesAsync();
			return person;
		}

		public async Task<Person?> UpdateAsync(Person person)
		{
			var existing = await _context.Persons.FindAsync(person.Id);
			if (existing == null) return null;
			_context.Entry(existing).CurrentValues.SetValues(person);
			await _context.SaveChangesAsync();
			return existing;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var person = await _context.Persons.FindAsync(id);
			if (person == null) return false;
			_context.Persons.Remove(person);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
