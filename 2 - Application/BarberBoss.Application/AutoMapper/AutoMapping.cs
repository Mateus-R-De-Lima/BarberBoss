using AutoMapper;
using BarberBoss.Communication.Filter;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Filter;

namespace BarberBoss.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            AutoMappingRequest();
            AutoMappingResponse();
        }

        private void AutoMappingRequest()
        {
            CreateMap<BillingRequest, Billing>();

            CreateMap<FilterRequest, BillingFilter>()
                .ForMember(s => s.Status, opt => opt.MapFrom(s => s.Status));

        }

        private void AutoMappingResponse()
        {
            CreateMap<Billing, BillingResponse>();
            CreateMap<Billing, BillingShortResponse>();
          
        }
    }
}
