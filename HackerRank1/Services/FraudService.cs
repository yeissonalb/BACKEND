using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Services
{
    public class FraudService : IFraudService
    {
        private readonly LibraryContext _libraryContext;

        public FraudService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<Fraud>> Get()
        {
            return await _libraryContext.Frauds.ToListAsync();
        }

        public async Task<Fraud> Add(Fraud fraud)
        {
            fraud.CreatedAt = DateTime.Now;

            await _libraryContext.Frauds.AddAsync(fraud);
            await _libraryContext.SaveChangesAsync();

            return fraud;
        }
    }

    public interface IFraudService
    {
        Task<IEnumerable<Fraud>> Get();

        Task<Fraud> Add(Fraud fraud);
    }
}