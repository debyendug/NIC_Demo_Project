using MediatR;
using NIC_Demo_Project.Common;
using NIC_Demo_Project.Context;
using NIC_Demo_Project.Models;
using NIC_Demo_Project.Response;

namespace NIC_Demo_Project.Features.NIC_EMP_DemoFeatures.Commands
{
    public class CreateNicEmpCommand : IRequest<ApiResponse>
    {
        public string? Name { get; set; }
        public string? Phno { get; set; }
        public int? Pin { get; set; }
        public int? Class { get; set; }
        public decimal? Markes { get; set; }


        public class Handler : IRequestHandler<CreateNicEmpCommand, ApiResponse>
        {
            private readonly IApplicationContext _context;

            public Handler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<ApiResponse> Handle(CreateNicEmpCommand request, CancellationToken cancellationToken)
            {
                ApiResponse response = new ApiResponse();
                try
                {
                    if (request != null)
                    {

                        NIC_EmpMain result = new()
                        {
                            Name = request.Name,
                            Phno = request.Phno,
                            Pin = request.Pin,
                            Class = request.Class,
                            Markes = request.Markes,
                            Activate = "A",

                        };
                        _context.NIC_EmpMains.Add(result);
                        await _context.SaveChangesAsync();

                        response.status = Status.Success;
                        response.result = result;
                        response.message = "Record Saved SuccessFully.!";


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
