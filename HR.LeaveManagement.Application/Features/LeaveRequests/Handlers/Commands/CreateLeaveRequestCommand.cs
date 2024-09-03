using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommand : IRequestHandler<CreateLeaveCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommand(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateLeaveCommand command, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(command.CreateLeaveRequestDto);
            var leaveRequestResponse = await _leaveRequestRepository.AddAsync(leaveRequest);
            return leaveRequestResponse.Id;
        }
    }
}