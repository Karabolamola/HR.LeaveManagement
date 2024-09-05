using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommand : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLeaveRequestCommand(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetAsync(command.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), command.Id);
            }

            await _leaveRequestRepository.DeleteAsync(leaveRequest);
            await _unitOfWork.SaveChangesToDatabaseAsync();
            return Unit.Value;
        }
    }
}