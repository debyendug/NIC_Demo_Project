using MediatR;
using NIC_Demo_Project.Common;
using NIC_Demo_Project.Context;
using NIC_Demo_Project.Response;

namespace NIC_Demo_Project.Features.NIC_EMP_DemoFeatures.Queries
{
    public class GetAllNicEmp : IRequest<ApiResponse>
    {
        public string? RecordStatus { get; set; }
        public PagingParameter? PagingParameters { get; set; }
        public string SearchString { get; set; } = String.Empty;

        public class Handler : IRequestHandler<GetAllNicEmp, ApiResponse>
        {
             private readonly IApplicationContext _context;

            public Handler(IApplicationContext applicationContext)
            {
                _context = applicationContext;
            }


            public async Task<ApiResponse> Handle(GetAllNicEmp request, CancellationToken cancellationToken)
            {
                ApiResponse response = new ApiResponse();
                PagingResponse pagingResponse = new PagingResponse();

                try
                {

                    var res = (from a in _context.NIC_EmpMains
                               where
                               (a.Name.Contains(request.SearchString.Trim() == String.Empty ? a.Name : request.SearchString))
                               select new
                               {
                                   a.EMId,
                                   a.Name,
                                   a.Phno,
                                   a.Pin,
                                   a.Class,
                                   a.Markes,
                                   a.Activate,
                               });

                    var totalCount = res.ToList().Count();
                    var result = res
                         .OrderByDescending(a => a.EMId)
                         .Skip((request.PagingParameters.PageNumber - 1) * request.PagingParameters.PageSize)
                         .Take(request.PagingParameters.PageSize)
                         .ToList();

                    pagingResponse.TotalCount = totalCount;
                    pagingResponse.PageNumber = request.PagingParameters.PageNumber;
                    pagingResponse.PageSize = request.PagingParameters.PageSize;

                    response.PagingDetails = pagingResponse;
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
