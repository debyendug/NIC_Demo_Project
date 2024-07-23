using NIC_Demo_Project.Common;
using NIC_Demo_Project.Context;
using NIC_Demo_Project.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace NIC_Demo_Project.Features.NIC_EMP_DemoFeatures.Commands
{
    public class ChangeStatusNicEmpCommand : IRequest<ApiResponse>
    {
        public int EMId { get; set; }

        public class Handler : IRequestHandler<ChangeStatusNicEmpCommand, ApiResponse>
        {
            private readonly IApplicationContext _context;
            public  Handler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<ApiResponse> Handle(ChangeStatusNicEmpCommand request, CancellationToken cancellationToken)
            {
                ApiResponse response = new ApiResponse();
                string message;
                try
                {
                    if (request != null)
                    {
                        var result = await _context.NIC_EmpMains.SingleOrDefaultAsync(c => c.EMId == request.EMId);                       
                        if (result != null)
                        {
                            if (result.Activate == "A")
                            {
                                result.Activate = "I";
                                message = "Record Inactivated Successfully";
                            }
                            else
                            {
                                result.Activate = "A";
                                message = "Record Activated Successfully";
                            }
                            _context.NIC_EmpMains.Update(result);
                            await _context.SaveChangesAsync();

                            response.status = Status.Success;
                            response.result = result;
                            response.message = message;
                        }
                        else
                        {
                            response.status = Status.Error;
                            response.result = null;
                            response.message = "Record Not Found";
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.statusCode = "500";
                    response.status = Status.Error;
                    response.result = null;
                    response.message = ex.InnerException.ToString();
                }
                return response;
            }

          
        }
    }
}
