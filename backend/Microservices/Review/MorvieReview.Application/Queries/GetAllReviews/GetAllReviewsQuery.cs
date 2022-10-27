using MediatR;
using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Application.Queries.GetAllReviews
{
    public class GetAllReviewsQuery:IRequest<IEnumerable<ReviewDto>>
    {
    }
}
