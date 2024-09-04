using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand command, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetAsync(command.Id);
            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), command.Id);
            }

            await _leaveAllocationRepository.DeleteAsync(leaveAllocation);
            return Unit.Value;
        }
    }
}