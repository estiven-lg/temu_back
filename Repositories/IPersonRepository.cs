using temu_back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace temu_back.Repositories
{
	public interface IPersonRepository
	{
		Task<IEnumerable<Person>> GetAllAsync();
		Task<Person?> GetByIdAsync(int id);
		Task<Person> AddAsync(Person person);
		Task<Person?> UpdateAsync(Person person);
		Task<bool> DeleteAsync(int id);
	}
}
