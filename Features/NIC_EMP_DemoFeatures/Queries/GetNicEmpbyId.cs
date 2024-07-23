using MediatR;
using NIC_Demo_Project.Common;
using NIC_Demo_Project.Context;
using NIC_Demo_Project.Response;

namespace NIC_Demo_Project.Features.NIC_EMP_DemoFeatures.Queries
{
    public class GetNicEmpbyId : IRequest<ApiResponse>
    {
        public int EMId { get; set; }
        public class Handler : IRequestHandler<GetNicEmpbyId, ApiResponse>
        {
            private readonly IApplicationContext _context;

            public Handler(IApplicationContext applicationContext)
            {
                _context = applicationContext;
            }


            public async Task<ApiResponse> Handle(GetNicEmpbyId request, CancellationToken cancellationToken)
            {
                ApiResponse response = new ApiResponse();

                try
                {

                    var result = (from a in _context.NIC_EmpMains
                               where a.EMId == request.EMId
                               select new
                               {
                                   a.EMId,
                                   a.Name,
                                   a.Phno,
                                   a.Pin,
                                   a.Class,
                                   a.Markes,
                                   a.Activate,
                               }).SingleOrDefault();

                  
                                       
                    response.status = Status.Success;
                    response.result = result;
                    response.message = Message.Success;

                }
                catch (Exception ex)
                {
                    response.statusCode = "500";
                    response.status = Status.Error;
                    response.result = null;
                    response.message = ex.Message;
                }
                return response;
            }


        }
    }
}
