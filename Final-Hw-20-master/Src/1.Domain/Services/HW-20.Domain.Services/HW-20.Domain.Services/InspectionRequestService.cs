using Azure.Core;
using HW_20.Domain.Contract.Repositoris;
using HW_20.Domain.Entites.Car;
using HW_20.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HW_18.Infrastructure.Service
{
    public class InspectionRequestService : IInspectionRequestService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public InspectionRequestService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> SubmitInspectionRequest(InspectionRequest request)
        {
            var dayOfWeek = request.RequestDate.DayOfWeek;
            var maxRequests = dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Friday
                ? _configuration.GetValue<int>("MaxRequestsEvenDays")
                : _configuration.GetValue<int>("MaxRequestsOddDays");

            var currentRequests = await _context.InspectionRequests.CountAsync(r => r.RequestDate.Date == request.RequestDate.Date);

            if (currentRequests >= maxRequests)
            {
                return false;
            }

            _context.InspectionRequests.Add(request);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<InspectionRequest>> GetPendingRequests()
        {
            return await _context.InspectionRequests.Where(r => !r.IsApproved && !r.IsRejected).ToListAsync();
        }

        public async Task<bool> ApproveRequest(int requestId)
        {
            var request = await _context.InspectionRequests.FindAsync(requestId);
            if (request == null) return false;

            request.IsApproved = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectRequest(int requestId, string reason)
        {
            var request = await _context.InspectionRequests.FindAsync(requestId);
            if (request == null) return false;

            request.IsRejected = true;
            _context.RejectedRequests.Add(new RejectedRequest { InspectionRequestId = requestId, Reason = reason });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}