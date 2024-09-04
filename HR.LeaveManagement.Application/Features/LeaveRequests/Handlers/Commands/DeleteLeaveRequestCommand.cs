using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommand : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommand(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(DeleteLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetAsync(command.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), command.Id);
            }

            await _leaveRequestRepository.DeleteAsync(leaveRequest);
            return Unit.Value;
        }
    }
}