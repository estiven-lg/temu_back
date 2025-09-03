using temu_back.Models;
using temu_back.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Services
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepository;

		public PersonService(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public async Task<IEnumerable<Person>> GetAllAsync()
		{
			return await _personRepository.GetAllAsync();
		}

		public async Task<Person?> GetByIdAsync(int id)
		{
			return await _personRepository.GetByIdAsync(id);
		}

		public async Task<Person> AddAsync(Person person)
		{
			return await _personRepository.AddAsync(person);
		}

		public async Task<Person?> UpdateAsync(Person person)
		{
			return await _personRepository.UpdateAsync(person);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _personRepository.DeleteAsync(id);
		}
	}
}
