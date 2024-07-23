using MediatR;
using Microsoft.EntityFrameworkCore;
using NIC_Demo_Project.Common;
using NIC_Demo_Project.Context;
using NIC_Demo_Project.Response;

namespace NIC_Demo_Project.Features.NIC_EMP_DemoFeatures.Commands
{
    public class UpdateNicEmpCommand : IRequest<ApiResponse>
    {
        public int EMId { get; set; }
        public string? Name { get; set; }
        public string? Phno { get; set; }
        public int? Pin { get; set; }
        public int? Class { get; set; }
        public decimal? Markes { get; set; }

        public class Handler : IRequestHandler<UpdateNicEmpCommand, ApiResponse>
        {
            private readonly IApplicationContext _context;            

            public Handler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<ApiResponse> Handle(UpdateNicEmpCommand request, CancellationToken cancellationToken)
            {
                ApiResponse response = new ApiResponse();
                try
                {
                    if (request != null)
                    {
                        var result = await _context.NIC_EmpMains.SingleOrDefaultAsync(x => x.EMId == request.EMId);

                        if (result != null)
                        {

                            result.Name = request.Name;
                            result.Phno = request.Phno;
                            result.Pin = request.Pin;
                            result.Class = request.Class;
                            result.Markes = request.Markes;


                            _context.NIC_EmpMains.Update(result);
                            await _context.SaveChangesAsync();

                            response.status = Status.Success;
                            response.result = result;
                            response.message = "Record updated successfully!";

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
