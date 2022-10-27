using MediatR;
using MorvieReview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorvieReview.Application.Queries.GetReview
{
    public class GetReviewQuery:IRequest<ReviewDto>
    {
        public Guid Id { get; set; }   
        public GetReviewQuery(Guid id)
        {
            Id = id;
        }
    }
}
